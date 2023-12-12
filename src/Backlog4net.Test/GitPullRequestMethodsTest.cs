using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api;
    using Api.Option;
    using Backlog4net.Internal.Json;
    using Backlog4net.Internal.Json.Activities;
    using Conf;
    using Newtonsoft.Json;
    using TestConfig;

    [TestClass]
    public class GitPullRequestMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;    
        private static string projectKey;
        private static long projectId;
        private static GitConfig gitConfig;
        private static User ownUser;
        private static long[] notifiedNumericUserIds;
        private static long[] assigneeUserIds;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();
            var users = await client.GetUsersAsync();

            projectKey = generalConfig.ProjectKey;
            var project = await client.GetProjectAsync(projectKey);
            projectId = project.Id;

            gitConfig = GitConfig.Instance.Value;

            ownUser = await client.GetMyselfAsync();

            var numericUserIds = (await client.GetUsersAsync()).ToDictionary(x => x.UserId, x => x.Id);
            notifiedNumericUserIds = new[]
                    {gitConfig.NotifiedUserId1, gitConfig.NotifiedUserId2, gitConfig.NotifiedUserId3}
                .Select(x => numericUserIds[x])
                .ToArray();

            assigneeUserIds = new[]
                    {gitConfig.AssigneeUserId1, gitConfig.AssigneeUserId2, gitConfig.AssigneeUserId3}
                .Select(x => numericUserIds[x])
                .ToArray();
        }

        [TestMethod]
        public async Task GetGitRepositoriesTestAsync()
        {
            var repositories = await client.GetGitRepositoriesAsync(projectId);
            Assert.AreNotEqual(repositories[0].Id, 0L);
            Assert.AreEqual(repositories[0].ProjectId, projectId);

            var repository = await client.GetGitRepositoryAsync(projectId, repositories[0].Id);
            Assert.AreEqual(repository.Id, repositories[0].Id);

            repository = JsonConvert.DeserializeObject<Repository>(File.ReadAllText(@"TestData\repository.json"), new RepositoryJsonImpl.JsonConverter());
            Assert.AreEqual(repository.Id, 16272L);
            Assert.AreEqual(repository.ProjectId, 61932L);
            Assert.AreEqual(repository.Name, "test");
            Assert.AreEqual(repository.Description, "test-description");
            Assert.AreEqual(repository.HookUrl, "test-hook-url");
            Assert.AreEqual(repository.HttpUrl, "https://test-4net.backlog.com/git/BLG4NT/test.git");
            Assert.AreEqual(repository.SshUrl, "test-4net@test-4net.git.backlog.com:/BLG4NT/test.git");
            Assert.AreEqual(repository.DisplayOrder, 2147483646L);
            Assert.AreEqual(repository.PushedAt, new DateTime(2017, 8, 20, 10, 29 , 8, DateTimeKind.Utc));
            Assert.AreEqual(repository.CreatedUser.Id, 137752L);
            Assert.AreEqual(repository.Created, new DateTime(2017, 8, 20, 10, 25, 48, DateTimeKind.Utc));
            Assert.AreEqual(repository.UpdatedUser.Id, 137752L);
            Assert.AreEqual(repository.Updated, new DateTime(2017, 8, 20, 10, 25, 48, DateTimeKind.Utc));
        }

        [TestMethod]
        public async Task PullRequestTestAsync()
        {
            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue1 = await client.CreateIssueAsync(new CreateIssueParams(projectId, "GetPullRequestTest1", issueTypes.First().Id, IssuePriorityType.High));
            var issue2 = await client.CreateIssueAsync(new CreateIssueParams(projectId, "GetPullRequestTest2", issueTypes.First().Id, IssuePriorityType.High));

            Attachment attachment1;
            using (var @params = new PostAttachmentParams("Test.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment1 = await client.PostAttachmentAsync(@params);
            }
            Attachment attachment2;
            using (var @params = new PostAttachmentParams("Test2.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST2"))))
            {
                attachment2 = await client.PostAttachmentAsync(@params);
            }

            var pullRequest = await client.AddPullRequestAsync(new AddPullRequestParams(projectId, gitConfig.RepoName, "PRSummary", "PRDescription", gitConfig.Base, gitConfig.Branch)
            {
                AssigneeId = assigneeUserIds[0],
                NotifiedUserIds = new[] { notifiedNumericUserIds[0], notifiedNumericUserIds[1] },
                IssueId = issue1.Id,
                AttachmentIds = new[] { attachment1.Id }
            });
            Assert.AreNotEqual(pullRequest.Id, 0L);
            Assert.AreEqual(pullRequest.Summary, "PRSummary");
            Assert.AreEqual(pullRequest.Description, "PRDescription");
            Assert.AreEqual(pullRequest.Base, gitConfig.Base);
            Assert.AreEqual(pullRequest.Branch, gitConfig.Branch);
            Assert.AreEqual(pullRequest.Assignee.Id, assigneeUserIds[0]);
            Assert.AreEqual(pullRequest.Issue.Id, issue1.Id);
            Assert.IsTrue(pullRequest.Attachments.Any(x => x.Name == attachment1.Name));

            var attachments = await client.GetPullRequestAttachmentsAsync(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number);
            Assert.AreEqual(attachments[0].Id, pullRequest.Attachments[0].Id);

            using (var attachmentData = await client.DownloadPullRequestAttachmentAsync(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number, attachments[0].Id))
            using (var memStream = new System.IO.MemoryStream())
            {
                await attachmentData.Content.CopyToAsync(memStream);
                var text = System.Text.Encoding.UTF8.GetString(memStream.ToArray());
                Assert.AreEqual(text, "TEST");
            }

            var count = await client.GetPullRequestCountAsync(projectId, gitConfig.RepoName);
            Assert.IsTrue(count > 0);

            count = await client.GetPullRequestCountAsync(projectId, gitConfig.RepoName, new PullRequestQueryParams()
            {
                Count = 10,
                Offset = 1,
                AssigneeIds = new[] { ownUser.Id },
                IssueIds = new[] { ownUser.Id },
                CreatedUserIds = new[] { ownUser.Id },
                StatusType = new[] { PullRequestStatusType.Open }
            });

            var pullRequests = await client.GetPullRequestsAsync(projectId, gitConfig.RepoName);
            Assert.IsTrue(pullRequests.Any(x => x.Id == pullRequest.Id));

            pullRequests = await client.GetPullRequestsAsync(projectId, gitConfig.RepoName, new PullRequestQueryParams()
            {
                Count = 10,
                Offset = 1,
                AssigneeIds = new[] { ownUser.Id },
                IssueIds = new[] { ownUser.Id },
                CreatedUserIds = new[] { ownUser.Id },
                StatusType = new[] { PullRequestStatusType.Open }
            });

            var pullRequestUpdated = await client.UpdatePullRequestAsync(new UpdatePullRequestParams(projectId, gitConfig.RepoName, pullRequest.Number)
            {
                Summary = "PRSummaryUpdated",
                Description = "PRDescription",
                AssigneeId = assigneeUserIds[1],
                NotifiedUserIds = new[] { notifiedNumericUserIds[1], notifiedNumericUserIds[2] },
                //IssueId = issue2.Id, デッドロックを引き起こしてしまう
            });
            Assert.AreNotEqual(pullRequestUpdated.Id, 0L);
            Assert.AreEqual(pullRequestUpdated.Summary, "PRSummaryUpdated");
            Assert.AreEqual(pullRequestUpdated.Description, "PRDescription");
            Assert.AreEqual(pullRequestUpdated.Assignee.Id, assigneeUserIds[1]);
            //Assert.AreEqual(pullRequestUpdated.Issue.Id, issue2.Id);

            var prComment = await client.AddPullRequestCommentAsync(new AddPullRequestCommentParams(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number, "Test") { NotifiedUserIds = new[] { notifiedNumericUserIds[0] }  });
            Assert.AreNotEqual(prComment.Id, 0L);
            Assert.AreEqual(prComment.Content, "Test");
            Assert.IsTrue(prComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[0]));
            Assert.AreEqual(prComment.CreatedUser.Id, ownUser.Id);
            Assert.IsNotNull(prComment.Created);
            Assert.IsNotNull(prComment.Updated);

            count = await client.GetPullRequestCommentCountAsync(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number);
            Assert.IsTrue(count > 0);

            var prComments = await client.GetPullRequestCommentsAsync(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number, new QueryParams()
            {
                MinId = 0,
                MaxId = int.MaxValue,
                Count = 100,
                Order = Order.Asc,
            });
            Assert.IsTrue(prComments.Any(x => x.Id == prComment.Id));

            var prCommentUpdated = await client.UpdatePullRequestCommentAsync(new UpdatePullRequestCommentParams(pullRequest.ProjectId, pullRequest.RepositoryId, pullRequest.Number, prComment.Id, "TestUpdated"));
            Assert.AreEqual(prCommentUpdated.Id, prComment.Id);
            Assert.AreEqual(prCommentUpdated.Content, "TestUpdated");

            await client.DeleteIssueAsync(issue1.Id);
            await client.DeleteIssueAsync(issue2.Id);
        }
    }
}
