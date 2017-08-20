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
    public class StatusResolutionPriorityMethodsTest
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
        public async Task GetStatusTestAsync()
        {
            var statuses = await client.GetStatusesAsync();
            Assert.IsTrue(statuses.Count > 0);
            Assert.IsTrue(statuses.Any(x => x.Id != 0));
            Assert.IsTrue(statuses.All(x => !string.IsNullOrEmpty(x.Name)));
        }

        [TestMethod]
        public async Task GetResolutionsTestAsync()
        {
            var resolutions = await client.GetResolutionsAsync();
            Assert.IsTrue(resolutions.Count > 0);
            Assert.IsTrue(resolutions.Any(x => x.Id != 0));
            Assert.IsTrue(resolutions.All(x => !string.IsNullOrEmpty(x.Name)));
        }


        [TestMethod]
        public async Task GetPrioritiesTestAsync()
        {
            var priorities = await client.GetPrioritiesAsync();
            Assert.IsTrue(priorities.Count > 0);
            Assert.IsTrue(priorities.Any(x => x.Id != 0));
            Assert.IsTrue(priorities.All(x => !string.IsNullOrEmpty(x.Name)));
        }
    }
}
