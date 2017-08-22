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
    public class NotificationMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static long projectId;
        private static User ownUser;

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

            ownUser = await client.GetMyselfAsync();
        }

        [TestMethod]
        public async Task NotificationTestAsync()
        {
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey2;
            var client2 = new BacklogClientFactory(conf).NewClient();

            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client2.CreateIssueAsync(new CreateIssueParams(projectId, "NotificationTestIssue", issueTypes.First().Id, IssuePriorityType.High)
            {
                NotifiedUserIds = new[] { ownUser.Id }
            });

            var count = await client.GetNotificationCountAsync(new GetNotificationCountParams());
            Assert.IsTrue(count > 0);
            await client.GetNotificationCountAsync(new GetNotificationCountParams() { AlreadyRead = true });
            await client.GetNotificationCountAsync(new GetNotificationCountParams() { ResourceAlreadyRead = true });

            await client.GetNotificationsAsync(new QueryParams() { Count = 100, MinId = 1, MaxId = int.MaxValue, Order = Order.Desc });
            var notifications = await client.GetNotificationsAsync();
            Assert.IsTrue(notifications.Any(x => x?.Issue.Id == issue.Id));

            var notification = notifications.First(x => x?.Issue.Id == issue.Id);
            await client.MarkAsReadNotificationAsync(notification.Id);

            await client.ResetNotificationCountAsync();

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public void DeserializeNotificationTest()
        {
            var notification = JsonConvert.DeserializeObject<NotificationJsonImpl>(File.ReadAllText(@"TestData\notification.json"));
            Assert.AreEqual(notification.Id, 14150866L);
            Assert.AreEqual(notification.IsAlreadyRead, true);
            Assert.AreEqual(notification.Reason, Reason.PullRequestUpdated);
            Assert.AreEqual(notification.IsResourceAlreadyRead, true);
            Assert.AreEqual(notification.Project.Id, 61932L);
            Assert.AreEqual(notification.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(notification.Project.Name, "Backlog4net-Test");
            Assert.AreEqual(notification.Project.IsChartEnabled, true);
            Assert.AreEqual(notification.Project.IsSubtaskingEnabled, true);
            Assert.AreEqual(notification.Project.IsArchived, true);
            Assert.AreEqual(notification.Project.TextFormattingRule, TextFormattingRule.Backlog);
            Assert.AreEqual(notification.Project.DisplayOrder, 2147483646L);
            Assert.AreEqual(notification.Issue.Id, 2954451L);
            Assert.AreEqual(notification.Issue.ProjectId, 61932L);
            Assert.AreEqual(notification.Issue.IssueKey, "BLG4NT-381");
            Assert.AreEqual(notification.Issue.KeyId, 381L);
            Assert.AreEqual(notification.Comment.Id, 14197041L);
            Assert.IsNull(notification.Comment.Content);
            Assert.AreEqual(notification.Comment.ChangeLog[0].Field, "notification");
            Assert.AreEqual(notification.Comment.ChangeLog[0].NotificationInfo.Type, "issue.create");
            Assert.AreEqual(notification.PullRequest.Id, 43875L);
            Assert.AreEqual(notification.PullRequest.Summary, "PRSummaryUpdated");
            Assert.AreEqual(notification.PullRequestComment.Id, 129562L);
            Assert.AreEqual(notification.PullRequestComment.ChangeLog[0].Field, "summary");
            Assert.AreEqual(notification.Sender.Id, 137752L);
            Assert.AreEqual(notification.Created, new DateTime(2017, 8, 20, 15, 54, 55, DateTimeKind.Utc));
        }
    }
}
