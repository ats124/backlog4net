using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    public class SpaceMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();
            var users = await client.GetUsersAsync();
        }

        [TestMethod]
        public async Task SpaceNotificationTestAsync()
        {
            var content = $"TestNotification{DateTime.Now}";
            var spaceNotificationUpdate = await client.UpdateSpaceNotificationAsync(content);
            Assert.AreEqual(spaceNotificationUpdate.Content, content);

            var spaceNotification = await client.GetSpaceNotificationAsync();
            Assert.AreEqual(spaceNotification.Content, content);
        }
    }
}
