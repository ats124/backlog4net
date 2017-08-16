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
    public class WebhookMethodsTest
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
        public async Task WebhookAsyncTest()
        {
            var webhook1 = await client.CreateWebhookAsync(new CreateWebhookParams(projectId, "TestWebhook1", "https://example.com/") { Description = "TestWebhookDescription1", AllEvent = true });
            Assert.AreNotEqual(webhook1.Id, 0L);
            Assert.AreEqual(webhook1.Name, "TestWebhook1");
            Assert.AreEqual(webhook1.HookUrl, "https://example.com/");
            Assert.AreEqual(webhook1.Description, "TestWebhookDescription1");
            Assert.AreEqual(webhook1.IsAllEvent, true);
            Assert.IsNotNull(webhook1.Created);
            Assert.AreEqual(webhook1.CreatedUser.Id, ownUser.Id);

            var webhook1Get = await client.GetWebhookAsync(projectId, webhook1.Id);
            Assert.AreNotEqual(webhook1Get.Id, 0L);
            Assert.AreEqual(webhook1Get.Name, "TestWebhook1");
            Assert.AreEqual(webhook1Get.HookUrl, "https://example.com/");
            Assert.AreEqual(webhook1Get.Description, "TestWebhookDescription1");
            Assert.AreEqual(webhook1Get.IsAllEvent, true);
            Assert.IsNotNull(webhook1Get.Created);
            Assert.AreEqual(webhook1Get.CreatedUser.Id, ownUser.Id);

            var webhook2 = await client.CreateWebhookAsync(new CreateWebhookParams(projectId, "TestWebhook2", "https://example.com/") { ActivityTypeIds = new[] { ActivityType.FileAdded, ActivityType.IssueCreated }  });
            Assert.IsTrue(webhook2.ActivityTypeIds.Any(x => x == ActivityType.FileAdded));
            Assert.IsTrue(webhook2.ActivityTypeIds.Any(x => x == ActivityType.IssueCreated));

            var webhooks = await client.GetWebhooksAsync(projectId);
            Assert.IsTrue(webhooks.Any(x => x.Id == webhook1.Id && x.Name == webhook1.Name));
            Assert.IsTrue(webhooks.Any(x => x.Id == webhook2.Id && x.Name == webhook2.Name));

            var webhook1Updated = await client.UpdateWebhookAsync(new UpdateWebhookParams(projectId, webhook1.Id) { Name = "TestWebhook1Updated", HookUrl = "https://example.com/Updated", Description = "TestWebhookDescription1Updated", AllEvent = false, ActivityTypeIds = new[] { ActivityType.IssueCreated, ActivityType.MilestoneCreated } });
            Assert.AreEqual(webhook1Updated.Name, "TestWebhook1Updated");
            Assert.AreEqual(webhook1Updated.HookUrl, "https://example.com/Updated");
            Assert.AreEqual(webhook1Updated.Description, "TestWebhookDescription1Updated");
            Assert.AreEqual(webhook1Updated.IsAllEvent, false);
            Assert.IsTrue(webhook1Updated.ActivityTypeIds.Any(x => x == ActivityType.IssueCreated));
            Assert.IsTrue(webhook1Updated.ActivityTypeIds.Any(x => x == ActivityType.MilestoneCreated));
            Assert.IsNotNull(webhook1Updated.Updated);
            Assert.AreEqual(webhook1Updated.UpdatedUser.Id, ownUser.Id);

            var webhook2Updated = await client.UpdateWebhookAsync(new UpdateWebhookParams(projectId, webhook2.Id) { AllEvent = true });
            Assert.AreEqual(webhook2Updated.IsAllEvent, true);

            var webhook1Deleted = await client.DeleteWebhookAsync(projectId, webhook1Updated.Id);
            Assert.AreEqual(webhook1Deleted.Id, webhook1Updated.Id);
            Assert.AreEqual(webhook1Deleted.Name, webhook1Updated.Name);

            webhooks = await client.GetWebhooksAsync(projectId);
            Assert.IsFalse(webhooks.Any(x => x.Id == webhook1.Id && x.Name == webhook1.Name));

            await client.DeleteWebhookAsync(projectId, webhook2Updated.Id);
        }
    }
}
