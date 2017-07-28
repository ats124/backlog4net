using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api;
    using Api.Option;
    using Conf;
    using TestConfig;

    [TestClass]
    public class IssueMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static object projectId;
        private static IList<IssueType> issueTypes;
        private static Version testVersion1;
        private static Version testVersion2;
        private static Milestone testMilestone1;
        private static Milestone testMilestone2;
        private static User ownUser;
        private static Category testCategory1;
        private static Category testCategory2;
        private static long numericAnotherUserId;
        private static CheckBoxCustomFieldSetting testCustomFieldSetting1;
        private static DateCustomFieldSetting testCustomFieldSetting2;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            projectKey = generalConfig.ProjectKey;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();

            var project = await client.GetProjectAsync(projectKey);
            projectId = project.Id;
            issueTypes = await client.GetIssueTypesAsync(projectId);

            ownUser = await client.GetMyselfAsync();

            var users = await client.GetUsersAsync();
            numericAnotherUserId = users.First(x => x.UserId == generalConfig.AnotherUserId).Id;

            testVersion1 = await client.AddVersionAsync(new AddVersionParams(projectKey, "TestVersion1"));
            testVersion2 = await client.AddVersionAsync(new AddVersionParams(projectKey, "TestVersion2"));

            testMilestone1 = await client.AddMilestoneAsync(new AddMilestoneParams(projectKey, "TestMilestone1"));
            testMilestone2 = await client.AddMilestoneAsync(new AddMilestoneParams(projectKey, "TestMilestone2"));

            testCategory1 = await client.AddCategoryAsync(new AddCategoryParams(projectKey, "TestCategory1"));
            testCategory2 = await client.AddCategoryAsync(new AddCategoryParams(projectKey, "TestCategory2"));

            testCustomFieldSetting1 = await client.AddCheckBoxCustomFieldAsync(
                new AddCheckBoxCustomFieldParams(projectKey, "TestCustomField")
                {
                    Items = new[] { "A", "B", "C" },
                });

            testCustomFieldSetting2 = await client.AddDateCustomFieldAsync(new AddDateCustomFieldParams(projectKey, "TestCustomField2"));
        }

        [ClassCleanup]
        public static async Task Cleanup()
        {
            await client.RemoveVersionAsync(projectKey, testVersion1.Id);
            await client.RemoveVersionAsync(projectKey, testVersion2.Id);

            await client.RemoveMilestoneAsync(projectKey, testMilestone1.Id);
            await client.RemoveMilestoneAsync(projectKey, testMilestone2.Id);

            await client.RemoveCategoryAsync(projectKey, testCategory1.Id);
            await client.RemoveCategoryAsync(projectKey, testCategory2.Id);

            await client.RemoveCustomFieldAsync(projectKey, testCustomFieldSetting1.Id);
            await client.RemoveCustomFieldAsync(projectKey, testCustomFieldSetting2.Id);
        }

        [TestMethod]
        public async Task IssuesTestAsync1()
        {
            var issueType1 = issueTypes.First();
            var issueType2 = issueTypes.Skip(1).First();

            Attachment attachment1;
            using (var @params = new PostAttachmentParams("Test.txt", new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment1 = await client.PostAttachmentAsync(@params);
            }
            Attachment attachment2;
            using (var @params = new PostAttachmentParams("Test2.txt", new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST2"))))
            {
                attachment2 = await client.PostAttachmentAsync(@params);
            }

            var create = await client.CreateIssueAsync(new CreateIssueParams(projectId, "ParentIssueTestSummary", issueType1.Id, IssuePriorityType.High)
            {
                Description = "ParentIssueTestDesc",
                StartDate = new DateTime(2017, 7, 1),
                DueDate = new DateTime(2017, 7, 2),
                EstimatedHours = 1.3m,
                ActualHours = 1.5m,
                CategoryIds = new object[] { testCategory1.Id, testCategory2.Id },
                AssigneeId = ownUser.Id,
                VersionIds = new object[] { testVersion1.Id, testVersion2.Id },
                MilestoneIds = new object[] { testMilestone1.Id, testMilestone2.Id },
                NotifiedUserIds = new object[] { ownUser.Id },
                AttachmentIds = new object[] { attachment1.Id, attachment2.Id },
                CustomFields = new CustomField[]
                {
                    CustomField.MultipleList(testCustomFieldSetting1.Id, testCustomFieldSetting1.Items.Select(x => x.Id).ToArray()),
                    CustomField.Date(testCustomFieldSetting2.Id, new DateTime(2017, 7, 1)), 
                }
            });
            Assert.AreEqual(create.Summary, "ParentIssueTestSummary");
            Assert.AreEqual(create.IssueType.Id, issueType1.Id);
            Assert.AreEqual(create.Priority.PriorityType, IssuePriorityType.High);
            Assert.AreEqual(create.Description, "ParentIssueTestDesc");
            Assert.AreEqual(create.StartDate, new DateTime(2017, 7, 1));
            Assert.AreEqual(create.DueDate, new DateTime(2017, 7, 2));
            Assert.AreEqual(create.EstimatedHours, 1.3m);
            Assert.AreEqual(create.ActualHours, 1.5m);
            Assert.IsTrue(create.Category.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testCategory1.Id, testCategory2.Id }.OrderBy(x => x)));
            Assert.AreEqual(create.Assignee.Id, ownUser.Id);
            Assert.IsTrue(create.Versions.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testVersion1.Id, testVersion2.Id }.OrderBy(x => x)));
            Assert.IsTrue(create.Milestone.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testMilestone1.Id, testMilestone2.Id }.OrderBy(x => x)));
            Assert.AreEqual(create.CreatedUser.Id, ownUser.Id);
            Assert.IsNotNull(create.Created);

            var attachments = await client.GetIssueAttachmentsAsync(create.IssueKey);
            Assert.IsTrue(attachments.Any(x => x.Name == attachment1.Name));
            Assert.IsTrue(attachments.Any(x => x.Name == attachment2.Name));

            using (var attachmentData = await client.DownloadIssueAttachmentAsync(create.IssueKey, attachments.First(x => x.Name == attachment1.Name).Id))
            using (var memStream = new System.IO.MemoryStream())
            {
                await attachmentData.Content.CopyToAsync(memStream);
                var text = System.Text.Encoding.UTF8.GetString(memStream.ToArray());
                Assert.AreEqual(text, "TEST");
            }

            var createChild = await client.CreateIssueAsync(new CreateIssueParams(projectId, "ChildIssueTestSummary", issueType1.Id, IssuePriorityType.High)
            {
                ParentIssueId = create.Id,
            });
            Assert.AreEqual(createChild.Summary, "ChildIssueTestSummary");
            Assert.AreEqual(createChild.ParentIssueId, create.Id);

            using (var @params = new PostAttachmentParams("Test.txt", new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment1 = await client.PostAttachmentAsync(@params);
            }
            using (var @params = new PostAttachmentParams("Test2.txt", new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST2"))))
            {
                attachment2 = await client.PostAttachmentAsync(@params);
            }

            var updatedChild = await client.UpdateIssueAsync(new UpdateIssueParams(createChild.Id)
            {
                Summary = "IssueTestSummaryUpdated",
                IssueTypeId = issueType2.Id,
                Priority = IssuePriorityType.Low,
                ParentIssueId = null,
                Description = "IssueTestDescriptionUpdated",
                StartDate = new DateTime(2017, 7, 3),
                DueDate = new DateTime(2017, 7, 4),
                EstimatedHours = 1.3m,
                ActualHours = 1.5m,
                CategoryIds = new object[] { testCategory1.Id, testCategory2.Id },
                AssigneeId = ownUser.Id,
                VersionIds = new object[] { testVersion1.Id, testVersion2.Id },
                MilestoneIds = new object[] { testMilestone1.Id, testMilestone2.Id },
                NotifiedUserIds = new object[] { ownUser.Id },
                AttachmentIds = new object[] { attachment1.Id, attachment2.Id },
                CustomFields = new CustomField[]
                {
                    CustomField.MultipleList(testCustomFieldSetting1.Id, testCustomFieldSetting1.Items.Select(x => x.Id).ToArray()),
                    CustomField.Date(testCustomFieldSetting2.Id, new DateTime(2017, 7, 1)),
                },
                Status = IssueStatusType.Closed,
                Resolution = IssueResolutionType.Duplication,
            });
            Assert.AreEqual(updatedChild.Summary, "IssueTestSummaryUpdated");
            Assert.AreEqual(updatedChild.IssueType.Id, issueType2.Id);
            Assert.AreEqual(updatedChild.ParentIssueId, null);
            Assert.AreEqual(updatedChild.Priority.PriorityType, IssuePriorityType.Low);
            Assert.AreEqual(updatedChild.Description, "IssueTestDescriptionUpdated");
            Assert.AreEqual(updatedChild.StartDate, new DateTime(2017, 7, 3));
            Assert.AreEqual(updatedChild.DueDate, new DateTime(2017, 7, 4));
            Assert.AreEqual(updatedChild.EstimatedHours, 1.3m);
            Assert.AreEqual(updatedChild.ActualHours, 1.5m);
            Assert.IsTrue(updatedChild.Category.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testCategory1.Id, testCategory2.Id }.OrderBy(x => x)));
            Assert.AreEqual(updatedChild.Assignee.Id, ownUser.Id);
            Assert.IsTrue(updatedChild.Versions.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testVersion1.Id, testVersion2.Id }.OrderBy(x => x)));
            Assert.IsTrue(updatedChild.Milestone.Select(x => x.Id).OrderBy(x => x).SequenceEqual(new[] { testMilestone1.Id, testMilestone2.Id }.OrderBy(x => x)));
            Assert.AreEqual(updatedChild.Status.StatusType, IssueStatusType.Closed);
            Assert.AreEqual(updatedChild.Resolution.ResolutionType, IssueResolutionType.Duplication);
            Assert.AreEqual(updatedChild.UpdatedUser.Id, ownUser.Id);
            Assert.IsNotNull(updatedChild.Updated);

            var attachmentsChild = await client.GetIssueAttachmentsAsync(updatedChild.IssueKey);
            Assert.IsTrue(attachmentsChild.Any(x => x.Name == attachment1.Name));
            Assert.IsTrue(attachmentsChild.Any(x => x.Name == attachment2.Name));

            var getIssue = await client.GetIssueAsync(updatedChild.IssueKey);
            Assert.AreEqual(getIssue.Id, updatedChild.Id);
            Assert.AreEqual(getIssue.Summary, "IssueTestSummaryUpdated");

            var getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId));
            Assert.IsTrue(getIssues.Any(x => x.Id == create.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == createChild.Id));

            var deleteChild = await client.DeleteIssueAsync(updatedChild.Id);
            Assert.AreEqual(deleteChild.Id, updatedChild.Id);

            var delete = await client.DeleteIssueAsync(create.Id);
            Assert.AreEqual(delete.Id, create.Id);

            getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId));
            Assert.IsFalse(getIssues.Any(x => x.Id == create.Id));
            Assert.IsFalse(getIssues.Any(x => x.Id == createChild.Id));

        }
    }
}
