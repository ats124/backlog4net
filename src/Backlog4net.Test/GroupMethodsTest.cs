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
    public class GroupMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static long projectId;
        private static User ownUser;
        private static User anotherUser;

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

            var conf2 = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf2.ApiKey = generalConfig.ApiKey2;
            var client2 = new BacklogClientFactory(conf).NewClient();
            anotherUser = await client2.GetMyselfAsync();
        }

        [TestMethod]
        public async Task GroupTestAsync()
        {
            var group = await client.CreateGroupAsync(new CreateGroupParams("TestGroup")
            {
                Members = new[] { ownUser.Id }
            });
            Assert.AreNotEqual(group.Id, 0L);
            Assert.AreEqual(group.Name, "TestGroup");
            Assert.IsTrue(group.Members.Any(x => x.Id == ownUser.Id));

            var groupGet = await client.GetGroupAsync(group.Id);
            Assert.AreEqual(groupGet.Id, group.Id);
            Assert.AreEqual(groupGet.Name, group.Name);
            Assert.IsTrue(groupGet.Members.Any(x => x.Id == ownUser.Id));

            var groupUpdated = await client.UpdateGroupAsync(new UpdateGroupParams(group.Id)
            {
                Name = "TestGroupUpdated",
                Members = new[] { anotherUser.Id }
            });
            Assert.AreEqual(groupUpdated.Id, group.Id);
            Assert.AreEqual(groupUpdated.Name, "TestGroupUpdated");
            Assert.IsTrue(groupGet.Members.Any(x => x.Id == anotherUser.Id));

            await client.GetGroupsAsync(new OffsetParams() { Count = 100, Offset = 1, Order = Order.Desc });

            var groupDeleted = await client.DeleteGroupAsync(groupUpdated.Id);
            Assert.AreEqual(groupDeleted.Id, groupDeleted.Id);
            Assert.AreEqual(groupDeleted.Name, groupDeleted.Name);
            Assert.IsTrue(groupDeleted.Members.Any(x => x.Id == anotherUser.Id));
        }
    }
}
