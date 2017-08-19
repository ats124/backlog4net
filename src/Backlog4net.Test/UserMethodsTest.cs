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
    public class UserMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static long projectId;

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
        }

        [TestMethod]
        public async Task UserAsyncTest()
        {
            var testUser1 = await client.CreateUserAsync(new CreateUserParams("testuser1", "password", "tesetuser1name", "testuser1@exsample.com", UserRoleType.Admin));
            Assert.AreNotEqual(testUser1.Id, 0L);
            Assert.AreEqual(testUser1.UserId, "testuser1");
            Assert.AreEqual(testUser1.Name, "tesetuser1name");
            Assert.AreEqual(testUser1.MailAddress, "testuser1@exsample.com");
            Assert.AreEqual(testUser1.RoleType, UserRoleType.Admin);

            var testUser1Get = await client.GetUserAsync(testUser1.Id);
            Assert.AreEqual(testUser1Get.Id, testUser1.Id);
            Assert.AreEqual(testUser1Get.UserId, testUser1.UserId);
            Assert.AreEqual(testUser1Get.Name, testUser1.Name);
            Assert.AreEqual(testUser1Get.MailAddress, testUser1.MailAddress);
            Assert.AreEqual(testUser1Get.RoleType, testUser1.RoleType);

            var users = await client.GetUsersAsync();
            Assert.IsTrue(users.Any(x => x.Id == testUser1.Id && x.UserId == testUser1.UserId));

            var userDeleted = await client.DeleteUserAsync(testUser1.Id);
            Assert.AreEqual(userDeleted.Id, testUser1.Id);
            Assert.AreEqual(userDeleted.UserId, testUser1.UserId);
        }

        [TestMethod]
        public async Task GetMyselfTestAsync()
        {
            var ownuser = await client.GetMyselfAsync();
            Assert.AreEqual(ownuser.UserId, generalConfig.OwnUserId);
        }
    }
}
