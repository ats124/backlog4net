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
        private static long projectId;
        private static IssuesConfig issuesConfig;
        private static long[] notifiedNumericUserIds;
        private static long[] assigneeUserIds;
        private static IList<IssueType> issueTypes;
        private static Version testVersion1;
        private static Version testVersion2;
        private static Milestone testMilestone1;
        private static Milestone testMilestone2;
        private static User ownUser;
        private static Category testCategory1;
        private static Category testCategory2;
        private static CheckBoxCustomFieldSetting testCustomFieldSetting1;
        private static DateCustomFieldSetting testCustomFieldSetting2;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            projectKey = generalConfig.ProjectKey;
            issuesConfig = IssuesConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();

            var project = await client.GetProjectAsync(projectKey);
            projectId = project.Id;
            issueTypes = await client.GetIssueTypesAsync(projectId);

            ownUser = await client.GetMyselfAsync();

            var numericUserIds = (await client.GetUsersAsync()).ToDictionary(x => x.UserId, x => x.Id);
            notifiedNumericUserIds = new[]
                    {issuesConfig.NotifiedUserId1, issuesConfig.NotifiedUserId2, issuesConfig.NotifiedUserId3}
                .Select(x => numericUserIds[x])
                .ToArray();

            assigneeUserIds = new[]
                    {issuesConfig.AssigneeUserId1, issuesConfig.AssigneeUserId2, issuesConfig.AssigneeUserId3}
                .Select(x => numericUserIds[x])
                .ToArray();

            testVersion1 = await client.AddVersionAsync(new AddVersionParams(projectKey, "TestVersion1"));
            testVersion2 = await client.AddVersionAsync(new AddVersionParams(projectKey, "TestVersion2"));

            testMilestone1 = await client.AddMilestoneAsync(new AddMilestoneParams(projectKey, "TestMilestone1"));
            testMilestone2 = await client.AddMilestoneAsync(new AddMilestoneParams(projectKey, "TestMilestone2"));

            testCategory1 = await client.AddCategoryAsync(new AddCategoryParams(projectKey, "TestCategory1"));
            testCategory2 = await client.AddCategoryAsync(new AddCategoryParams(projectKey, "TestCategory2"));

            testCustomFieldSetting1 = await client.AddCheckBoxCustomFieldAsync(
                new AddCheckBoxCustomFieldParams(projectKey, "TestCustomField")
                {
                    Items = new[] {"A", "B", "C"},
                });

            testCustomFieldSetting2 =
                await client.AddDateCustomFieldAsync(new AddDateCustomFieldParams(projectKey, "TestCustomField2"));
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

            var create = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "ParentIssueTestSummary", issueType1.Id, IssuePriorityType.High)
                {
                    Description = "ParentIssueTestDesc",
                    StartDate = new DateTime(2017, 7, 1),
                    DueDate = new DateTime(2017, 7, 2),
                    EstimatedHours = 1.3m,
                    ActualHours = 1.5m,
                    CategoryIds = new[] {testCategory1.Id, testCategory2.Id},
                    AssigneeId = ownUser.Id,
                    VersionIds = new[] { testVersion1.Id, testVersion2.Id},
                    MilestoneIds = new[] { testMilestone1.Id, testMilestone2.Id},
                    NotifiedUserIds = new[] { ownUser.Id},
                    AttachmentIds = new[] { attachment1.Id, attachment2.Id},
                    CustomFields = new CustomField[]
                    {
                        CustomField.MultipleList(testCustomFieldSetting1.Id,
                            testCustomFieldSetting1.Items.Select(x => x.Id).ToArray()),
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
            Assert.IsTrue(create.Category.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testCategory1.Id, testCategory2.Id}.OrderBy(x => x)));
            Assert.AreEqual(create.Assignee.Id, ownUser.Id);
            Assert.IsTrue(create.Versions.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testVersion1.Id, testVersion2.Id}.OrderBy(x => x)));
            Assert.IsTrue(create.Milestone.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testMilestone1.Id, testMilestone2.Id}.OrderBy(x => x)));
            Assert.AreEqual(create.CreatedUser.Id, ownUser.Id);
            Assert.IsNotNull(create.Created);

            var attachments = await client.GetIssueAttachmentsAsync(create.IssueKey);
            Assert.IsTrue(attachments.Any(x => x.Name == attachment1.Name));
            Assert.IsTrue(attachments.Any(x => x.Name == attachment2.Name));

            using (var attachmentData =
                await client.DownloadIssueAttachmentAsync(create.IssueKey,
                    attachments.First(x => x.Name == attachment1.Name).Id))
            using (var memStream = new System.IO.MemoryStream())
            {
                await attachmentData.Content.CopyToAsync(memStream);
                var text = System.Text.Encoding.UTF8.GetString(memStream.ToArray());
                Assert.AreEqual(text, "TEST");
            }

            var createChild = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "ChildIssueTestSummary", issueType1.Id, IssuePriorityType.High)
                {
                    ParentIssueId = create.Id,
                });
            Assert.AreEqual(createChild.Summary, "ChildIssueTestSummary");
            Assert.AreEqual(createChild.ParentIssueId, create.Id);

            using (var @params = new PostAttachmentParams("Test.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment1 = await client.PostAttachmentAsync(@params);
            }
            using (var @params = new PostAttachmentParams("Test2.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST2"))))
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
                CategoryIds = new[] {testCategory1.Id, testCategory2.Id},
                AssigneeId = ownUser.Id,
                VersionIds = new[] {testVersion1.Id, testVersion2.Id},
                MilestoneIds = new[] {testMilestone1.Id, testMilestone2.Id},
                NotifiedUserIds = new[] {ownUser.Id},
                AttachmentIds = new[] {attachment1.Id, attachment2.Id},
                CustomFields = new CustomField[]
                {
                    CustomField.MultipleList(testCustomFieldSetting1.Id,
                        testCustomFieldSetting1.Items.Select(x => x.Id).ToArray()),
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
            Assert.IsTrue(updatedChild.Category.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testCategory1.Id, testCategory2.Id}.OrderBy(x => x)));
            Assert.AreEqual(updatedChild.Assignee.Id, ownUser.Id);
            Assert.IsTrue(updatedChild.Versions.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testVersion1.Id, testVersion2.Id}.OrderBy(x => x)));
            Assert.IsTrue(updatedChild.Milestone.Select(x => x.Id).OrderBy(x => x)
                .SequenceEqual(new[] {testMilestone1.Id, testMilestone2.Id}.OrderBy(x => x)));
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

        [TestMethod]
        public async Task DeleteIssueAttachmentTestAsync()
        {
            var issueType1 = issueTypes.First();
            var issueType2 = issueTypes.Skip(1).First();

            Attachment attachment;
            using (var @params = new PostAttachmentParams("Test.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment = await client.PostAttachmentAsync(@params);
            }

            var create = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "ParentIssueTestSummary", issueType1.Id, IssuePriorityType.High)
                {
                    AttachmentIds = new[] {attachment.Id}
                });

            var attachmentDeleted = await client.DeleteIssueAttachmentAsync(create.Id, create.Attachments[0].Id);
            Assert.AreEqual(attachmentDeleted.Id, create.Attachments[0].Id);

            var getIssue = await client.GetIssueAsync(create.Id);
            Assert.IsFalse(getIssue.Attachments.Any());

            await client.DeleteIssueAsync(create.Id);
        }

        [TestMethod]
        public async Task IssueCommentTestAsync()
        {
            var issueType1 = issueTypes.First();

            var issue = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary", issueType1.Id, IssuePriorityType.High));

            Attachment attachment;
            using (var @params = new PostAttachmentParams("Test.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment = await client.PostAttachmentAsync(@params);
            }

            var issueComment = await client.AddIssueCommentAsync(new AddIssueCommentParams(issue.Id, "TestComment")
            {
                NotifiedUserIds = new[] {notifiedNumericUserIds[0], notifiedNumericUserIds[1]},
                AttachmentIds = new[] {attachment.Id}
            });
            Assert.AreEqual(issueComment.Content, "TestComment");
            Assert.AreEqual(issueComment.CreatedUser.Id, ownUser.Id);
            Assert.IsNotNull(issueComment.Created);
            Assert.IsTrue(issueComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[0]));
            Assert.IsTrue(issueComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[1]));
            Assert.AreEqual(issueComment.ChangeLog[0].AttachmentInfo.Name, attachment.Name);

            var issueCommentAddNotifi =
                await client.AddIssueCommentNotificationAsync(new AddIssueCommentNotificationParams(issue.Id,
                    issueComment.Id, new[] {notifiedNumericUserIds[2]}));
            Assert.IsTrue(issueCommentAddNotifi.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[2]));

            var notifications = await client.GetIssueCommentNotificationsAsync(issue.Id, issueComment.Id);
            Assert.IsTrue(notifications.Any(x => x.User.Id == notifiedNumericUserIds[0]));
            Assert.IsTrue(notifications.Any(x => x.User.Id == notifiedNumericUserIds[1]));
            Assert.IsTrue(notifications.Any(x => x.User.Id == notifiedNumericUserIds[2]));

            var issueCommentUpdated =
                await client.UpdateIssueCommentAsync(
                    new UpdateIssueCommentParams(issue.Id, issueComment.Id, "TestCommentUpdated"));
            Assert.AreEqual(issueCommentUpdated.Content, "TestCommentUpdated");

            var getIssueComment = await client.GetIssueCommentAsync(issue.Id, issueCommentUpdated.Id);
            Assert.AreEqual(getIssueComment.Id, issueCommentUpdated.Id);
            Assert.AreEqual(getIssueComment.Content, "TestCommentUpdated");
            Assert.AreEqual(getIssueComment.CreatedUser.Id, ownUser.Id);
            Assert.IsNotNull(getIssueComment.Created);
            Assert.IsNotNull(getIssueComment.Updated);
            Assert.IsTrue(getIssueComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[0]));
            Assert.IsTrue(getIssueComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[1]));
            Assert.IsTrue(getIssueComment.Notifications.Any(x => x.User.Id == notifiedNumericUserIds[2]));
            Assert.IsTrue(getIssueComment.ChangeLog.Any(x => x.AttachmentInfo?.Name == attachment.Name));

            var issueComment2 = await client.AddIssueCommentAsync(new AddIssueCommentParams(issue.Id, "TestComment2"));

            var issueCount = await client.GetIssueCommentCountAsync(issue.Id);
            Assert.AreEqual(issueCount, 2);

            var issueComments = await client.GetIssueCommentsAsync(issue.Id, new QueryParams() {Count = 1});
            Assert.AreEqual(issueComments.Count, 1);
            issueComments = await client.GetIssueCommentsAsync(issue.Id, new QueryParams() {Order = Order.Asc});
            Assert.AreEqual(issueComments.Count, 2);
            Assert.AreEqual(issueComments[0].Id, issueCommentUpdated.Id);
            issueComments = await client.GetIssueCommentsAsync(issue.Id, new QueryParams() {Order = Order.Desc});
            Assert.AreEqual(issueComments.Count, 2);
            Assert.AreEqual(issueComments[0].Id, issueComment2.Id);
            issueComments =
                await client.GetIssueCommentsAsync(issue.Id, new QueryParams() {MaxId = issueCommentUpdated.Id + 1});
            Assert.AreEqual(issueComments.Count, 1);
            Assert.AreEqual(issueComments[0].Id, issueCommentUpdated.Id);
            issueComments =
                await client.GetIssueCommentsAsync(issue.Id, new QueryParams() {MinId = issueComment2.Id - 1});
            Assert.AreEqual(issueComments.Count, 1);
            Assert.AreEqual(issueComments[0].Id, issueComment2.Id);

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public async Task IssueSharedFileTestAsync()
        {
            var issueType1 = issueTypes.First();

            var sharedFiles =
                await client.GetSharedFilesAsync(generalConfig.ProjectKey, issuesConfig.SharedFileDirectory);
            var file1 = sharedFiles.First(x => x.Name == issuesConfig.SharedFile1);
            var file2 = sharedFiles.First(x => x.Name == issuesConfig.SharedImageFile1);

            var issue = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary", issueType1.Id, IssuePriorityType.High));
            var linkedShareFiles = await client.LinkIssueSharedFileAsync(issue.Id, new object[] {file1.Id, file2.Id});
            Assert.AreEqual(linkedShareFiles.Count, 2);
            Assert.IsTrue(linkedShareFiles.Any(x => x.Id == file1.Id && x.Dir == file1.Dir && x.Name == file1.Name &&
                                                    x.Size == file1.Size));
            Assert.IsTrue(linkedShareFiles.Any(x => x.Id == file2.Id));

            var getGetIssueSharedFiles = await client.GetIssueSharedFilesAsync(issue.Id);
            Assert.AreEqual(getGetIssueSharedFiles.Count, 2);
            Assert.IsTrue(getGetIssueSharedFiles.Any(x => x.Id == file1.Id && x.Dir == file1.Dir && x.Name == file1.Name &&
                                                    x.Size == file1.Size));
            Assert.IsTrue(getGetIssueSharedFiles.Any(x => x.Id == file2.Id));

            var sharedFileUnlinked = await client.UnlinkIssueSharedFileAsync(issue.Id, linkedShareFiles[0].Id);
            Assert.AreEqual(sharedFileUnlinked.Id, linkedShareFiles[0].Id);

            var getIssue = await client.GetIssueAsync(issue.Id);
            Assert.AreEqual(getIssue.SharedFiles.Length, 1);
            Assert.AreEqual(getIssue.SharedFiles[0].Id, file2.Id);

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public async Task GetIssuesTestAsync()
        {
            var issueType1 = issueTypes.First();
            var issueType2 = issueTypes.Skip(1).First();

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

            var issue1 = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary1", issueType1.Id, IssuePriorityType.High)
                {
                    VersionIds = new[] {testVersion1.Id},
                    MilestoneIds = new[] {testMilestone1.Id},
                    CategoryIds = new[] {testCategory1.Id},
                    StartDate = new DateTime(2017, 7, 1),
                    DueDate = new DateTime(2017, 8, 1),
                    AssigneeId = assigneeUserIds[0],
                    AttachmentIds = new[] {attachment1.Id},
                });
            await Task.Delay(TimeSpan.FromSeconds(1.1));
            var issue2 = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary2", issueType2.Id, IssuePriorityType.High)
                {
                    CategoryIds = new[] {testCategory2.Id},
                    ParentIssueId = issue1.Id,
                    StartDate = new DateTime(2017, 7, 2),
                    DueDate = new DateTime(2017, 8, 2),
                    AssigneeId = assigneeUserIds[1],
                    AttachmentIds = new[] {attachment2.Id},
                });
            await Task.Delay(TimeSpan.FromSeconds(1.1));
            var issue3 = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary3", issueType1.Id, IssuePriorityType.Low)
                {
                    Description = "ABC",
                    VersionIds = new[] {testVersion2.Id},
                    StartDate = new DateTime(2017, 7, 3),
                    DueDate = new DateTime(2017, 8, 3),
                    AssigneeId = assigneeUserIds[2]
                });
            await Task.Delay(TimeSpan.FromSeconds(1.1));
            var issue4 = await client.CreateIssueAsync(
                new CreateIssueParams(projectId, "TestSummary4", issueType1.Id, IssuePriorityType.Normal)
                {
                    Description = "KeywordForTest",
                    MilestoneIds = new[] {testMilestone2.Id},
                    ParentIssueId = issue3.Id,
                    StartDate = new DateTime(2017, 7, 4),
                    DueDate = new DateTime(2017, 8, 4),
                });
            var issueIds = new[] {issue1.Id, issue2.Id, issue3.Id, issue4.Id};

            var getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId) {Count = 1});
            Assert.AreEqual(getIssues.Count, 1);

            getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId) {Order = Order.Asc});
            Assert.IsTrue(getIssues[0].Id < getIssues[1].Id);

            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Count = 2, Offset = 2, Order = Order.Desc});
            Assert.AreEqual(getIssues[0].Id, issue2.Id);

            var getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = new[] {issue1.Id, issue2.Id}});
            Assert.AreEqual(getIssuesCount, 2);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = new[] {issue1.Id, issue2.Id}});
            Assert.AreEqual(getIssues.Count, 2);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue1.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {ParentIssueIds = new[] {issue1.Id, issue4.Id}});
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {ParentIssueIds = new[] {issue1.Id, issue4.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));

            //日本時間のタイムゾーン情報
            var jstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var date = TimeZoneInfo.ConvertTimeFromUtc(issue1.Created.Value, jstTimeZoneInfo).Date;

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {CreatedSince = date, CreatedUntil = date.AddDays(1)});
            Assert.IsTrue(getIssuesCount >= 4);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {CreatedSince = date, CreatedUntil = date.AddDays(1)});
            Assert.IsTrue(getIssues.Count >= 4);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue1.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue3.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue4.Id));

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {UpdatedSince = date, UpdatedUntil = date.AddDays(1)});
            Assert.IsTrue(getIssuesCount >= 4);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {UpdatedSince = date, UpdatedUntil = date.AddDays(1)});
            Assert.IsTrue(getIssues.Count >= 4);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue1.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue3.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue4.Id));

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, IssueTypeIds = new[] {issueType2.Id}});
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, IssueTypeIds = new[] {issueType2.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue2.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId)
                    {
                        Ids = issueIds,
                        CategoryIds = new[] {testCategory2.Id}
                    });
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, CategoryIds = new[] {testCategory2.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue2.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, VersionIds = new[] {testVersion2.Id}});
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, VersionIds = new[] {testVersion2.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue3.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId)
                    {
                        Ids = issueIds,
                        MilestoneIds = new[] {testMilestone2.Id}
                    });
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, MilestoneIds = new[] {testMilestone2.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue4.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId)
                    {
                        Ids = issueIds,
                        MilestoneIds = new[] {testMilestone2.Id}
                    });
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, MilestoneIds = new[] {testMilestone2.Id}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue4.Id);

            await client.UpdateIssueAsync(new UpdateIssueParams(issue4.Id)
            {
                Status = IssueStatusType.Resolved,
                Resolution = IssueResolutionType.Fixed,
            });

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, Statuses = new[] {IssueStatusType.Resolved}});
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, Statuses = new[] {IssueStatusType.Resolved}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue4.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, Priorities = new[] {IssuePriorityType.Low}});
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, Priorities = new[] {IssuePriorityType.Low}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue3.Id);

            getIssuesCount = await client.GetIssuesCountAsync(new GetIssuesCountParams(projectId)
            {
                Ids = issueIds,
                AssigneeIds = new[] {assigneeUserIds[0], assigneeUserIds[1]}
            });
            Assert.AreEqual(getIssuesCount, 2);
            getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId)
            {
                Ids = issueIds,
                AssigneeIds = new[] {assigneeUserIds[0], assigneeUserIds[1]}
            });
            Assert.AreEqual(getIssues.Count, 2);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue1.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId)
                    {
                        Ids = issueIds,
                        Resolutions = new[] {IssueResolutionType.Fixed}
                    });
            Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, Resolutions = new[] {IssueResolutionType.Fixed}});
            Assert.AreEqual(getIssues.Count, 1);
            Assert.AreEqual(getIssues[0].Id, issue4.Id);

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId)
                    {
                        Ids = issueIds,
                        ParentChildType = GetIssuesParentChildType.Child
                    });
            Assert.AreEqual(getIssuesCount, 2);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, ParentChildType = GetIssuesParentChildType.Child});
            Assert.AreEqual(getIssues.Count, 2);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue4.Id));

            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, Attachment = true});
            Assert.AreEqual(getIssuesCount, 2);
            getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId) {Ids = issueIds, Attachment = true});
            Assert.AreEqual(getIssues.Count, 2);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue1.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue2.Id));

            var sharedFiles =
                await client.GetSharedFilesAsync(generalConfig.ProjectKey, issuesConfig.SharedFileDirectory);
            var file1 = sharedFiles.First(x => x.Name == issuesConfig.SharedFile1);
            var file2 = sharedFiles.First(x => x.Name == issuesConfig.SharedImageFile1);
            await client.LinkIssueSharedFileAsync(issue3.Id, new object[] {file1.Id});
            await client.LinkIssueSharedFileAsync(issue4.Id, new object[] {file2.Id});
            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, SharedFile = true});
            Assert.AreEqual(getIssuesCount, 2);
            getIssues = await client.GetIssuesAsync(new GetIssuesParams(projectId) {Ids = issueIds, SharedFile = true});
            Assert.AreEqual(getIssues.Count, 2);
            Assert.IsTrue(getIssues.Any(x => x.Id == issue3.Id));
            Assert.IsTrue(getIssues.Any(x => x.Id == issue4.Id));

            // キーワードのインデックスをつくるのにしばらく時間かかるっぽく
            // CIに組み込むのは厳しいのでエラーがでないかだけチェック
            getIssuesCount =
                await client.GetIssuesCountAsync(
                    new GetIssuesCountParams(projectId) {Ids = issueIds, Keyword = "KeywordForTest"});
            //Assert.AreEqual(getIssuesCount, 1);
            getIssues = await client.GetIssuesAsync(
                new GetIssuesParams(projectId) {Ids = issueIds, Keyword = "KeywordForTest"});
            //Assert.AreEqual(getIssues.Count, 1);
            //Assert.AreEqual(getIssues[0].Id, issue4.Id);

            await client.DeleteIssueAsync(issue4.Id);
            await client.DeleteIssueAsync(issue3.Id);
            await client.DeleteIssueAsync(issue2.Id);
            await client.DeleteIssueAsync(issue1.Id);
        }

        [TestMethod]
        public async Task GetIssuesCustomFieldTestAsync()
        {
            // 課題を追加してすぐにカスタム属性検索はできないのでCIに組み込むのは厳しい
            // 手動でテスト

            //var issueType1 = issueTypes.First();
            //var text = await client.AddTextCustomFieldAsync(new AddTextCustomFieldParams(projectKey, "TextCustomFieldText"));
            //var textArea = await client.AddTextAreaCustomFieldAsync(new AddTextAreaCustomFieldParams(projectKey, "TextAreaCustomFieldText"));        
            //var numeric = await client.AddNumericCustomFieldAsync(new AddNumericCustomFieldParams(projectKey, "CustomNumericFieldName"));
            //var date = await client.AddDateCustomFieldAsync(new AddDateCustomFieldParams(projectKey, "CustomDateFieldName1"));
            //var singleList = await client.AddSingleListCustomFieldAsync(new AddSingleListCustomFieldParams(generalConfig.ProjectKey, "CustomSingleListFieldName")
            //{
            //    Items = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" }
            //});
            //var multipleList = await client.AddMultipleListCustomFieldAsync(new AddMultipleListCustomFieldParams(generalConfig.ProjectKey, "CustomMultipleListFieldName")
            //{
            //    Items = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" }
            //});
            //var checkBox = await client.AddCheckBoxCustomFieldAsync(new AddCheckBoxCustomFieldParams(generalConfig.ProjectKey, "CustomCheckBoxFieldName")
            //{
            //    Items = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" }
            //});
            //var radio = await client.AddRadioCustomFieldAsync(new AddRadioCustomFieldParams(generalConfig.ProjectKey, "CustomRadioFieldName")
            //{
            //    Items = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" }
            //});

            //try
            //{
            //    var issue1 = await client.CreateIssueAsync(
            //        new CreateIssueParams(projectId, "CustomFieldTest1", issueType1.Id, IssuePriorityType.High)
            //        {
            //            CustomFields = new CustomField[]
            //            {
            //                CustomField.Text(text.Id, "Text1"),
            //                CustomField.TextArea(textArea.Id, "TextArea1"),
            //                CustomField.Numeric(numeric.Id, 100.5m),
            //                CustomField.Date(date.Id, new DateTime(2017, 7, 1)),
            //                CustomField.SingleList(singleList.Id, singleList.Items[0].Id),
            //                CustomField.MultipleList(multipleList.Id, multipleList.Items[1].Id, multipleList.Items[2].Id),
            //                CustomField.CheckBox(checkBox.Id, checkBox.Items[3].Id, checkBox.Items[4].Id),
            //                CustomField.Radio(radio.Id, radio.Items[5].Id),
            //            }
            //        });

            //    var issue2 = await client.CreateIssueAsync(
            //        new CreateIssueParams(projectId, "CustomFieldTest2", issueType1.Id, IssuePriorityType.High)
            //        {
            //            CustomFields = new CustomField[]
            //            {
            //                CustomField.Text(text.Id, "Text2"),
            //                CustomField.TextArea(textArea.Id, "TextArea2"),
            //                CustomField.Numeric(numeric.Id, 200.5m),
            //                CustomField.Date(date.Id, new DateTime(2017, 8, 1)),
            //                CustomField.SingleList(singleList.Id, singleList.Items[6].Id),
            //                CustomField.MultipleList(multipleList.Id, multipleList.Items[7].Id, multipleList.Items[8].Id),
            //                CustomField.CheckBox(checkBox.Id, checkBox.Items[9].Id, checkBox.Items[10].Id),
            //                CustomField.Radio(radio.Id, radio.Items[11].Id),
            //            }
            //        });

            //    var issueIds = new object[] { issue1.Id, issue2.Id };
            //    var getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByKeyword(text.Id, "Text1"),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    var getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByKeyword(text.Id, "Text1"),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByKeyword(textArea.Id, "TextArea1"),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByKeyword(textArea.Id, "TextArea1"),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByNumeric(numeric.Id, 100.1m, 100.6m),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByNumeric(numeric.Id, 100.1m, 100.6m),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByDate(date.Id, new DateTime(2017, 6, 30), new DateTime(2017, 7, 2)),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByDate(date.Id, new DateTime(2017, 6, 30), new DateTime(2017, 7, 2)),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(singleList.Id, singleList.Items[0].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(singleList.Id, singleList.Items[0].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(multipleList.Id, multipleList.Items[1].Id, multipleList.Items[2].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(multipleList.Id, multipleList.Items[1].Id, multipleList.Items[2].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(checkBox.Id, checkBox.Items[3].Id, checkBox.Items[4].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(checkBox.Id, checkBox.Items[3].Id, checkBox.Items[4].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    issueIds = new object[] { issue1.Id, issue2.Id };
            //    getIssuesCount =
            //        await client.GetIssuesCountAsync(
            //            new GetIssuesCountParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(radio.Id, radio.Items[5].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssuesCount, 1);
            //    getIssues =
            //        await client.GetIssuesAsync(
            //            new GetIssuesParams(projectId)
            //            {
            //                Ids = issueIds,
            //                CustomFields = new List<GetIssuesCustomField>()
            //                {
            //                    GetIssuesCustomField.ByItems(radio.Id, radio.Items[5].Id),
            //                }
            //            });
            //    Assert.AreEqual(getIssues.Count, 1);
            //    Assert.AreEqual(getIssues[0].Id, issue1.Id);

            //    await client.DeleteIssueAsync(issue1.Id);
            //    await client.DeleteIssueAsync(issue2.Id);
            //}
            //finally 
            //{
            //    try
            //    {
            //        await client.RemoveCustomFieldAsync(projectKey, text.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, textArea.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, numeric.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, date.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, singleList.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, multipleList.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, checkBox.Id);
            //        await client.RemoveCustomFieldAsync(projectKey, radio.Id);
            //    }
            //    catch
            //    {
            //    }
            //}

            //var customFields = await client.GetCustomFieldsAsync(projectKey);
            //var text = customFields.First(x => x.Name == "TextCustomFieldText");
            //var textArea = customFields.First(x => x.Name == "TextAreaCustomFieldText");
            //var numeric = customFields.First(x => x.Name == "CustomNumericFieldName");
            //var date = customFields.First(x => x.Name == "CustomDateFieldName1");
            //var singleList = (SingleListCustomFieldSetting)customFields.First(x => x.Name == "CustomSingleListFieldName");
            //var multipleList = (MultipleListCustomFieldSetting)customFields.First(x => x.Name == "CustomMultipleListFieldName");
            //var checkBox = (CheckBoxCustomFieldSetting)customFields.First(x => x.Name == "CustomCheckBoxFieldName");
            //var radio = (RadioCustomFieldSetting)customFields.First(x => x.Name == "CustomRadioFieldName");

            //var getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByKeyword(text.Id, "Text1"),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //var getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByKeyword(text.Id, "Text1"),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByKeyword(textArea.Id, "TextArea1"),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByKeyword(textArea.Id, "TextArea1"),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByNumeric(numeric.Id, 100.1m, 100.6m),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByNumeric(numeric.Id, 100.1m, 100.6m),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByDate(date.Id, new DateTime(2017, 6, 30), new DateTime(2017, 7, 2)),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByDate(date.Id, new DateTime(2017, 6, 30), new DateTime(2017, 7, 2)),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(singleList.Id, singleList.Items[0].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(singleList.Id, singleList.Items[0].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(multipleList.Id, multipleList.Items[1].Id, multipleList.Items[2].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(multipleList.Id, multipleList.Items[1].Id, multipleList.Items[2].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(checkBox.Id, checkBox.Items[3].Id, checkBox.Items[4].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(checkBox.Id, checkBox.Items[3].Id, checkBox.Items[4].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);

            //getIssuesCount =
            //    await client.GetIssuesCountAsync(
            //        new GetIssuesCountParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(radio.Id, radio.Items[5].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssuesCount, 1);
            //getIssues =
            //    await client.GetIssuesAsync(
            //        new GetIssuesParams(projectId)
            //        {
            //            CustomFields = new List<GetIssuesCustomField>()
            //            {
            //                    GetIssuesCustomField.ByItems(radio.Id, radio.Items[5].Id),
            //            }
            //        });
            //Assert.AreEqual(getIssues.Count, 1);
        }
    }
}
