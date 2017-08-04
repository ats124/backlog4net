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
        public async Task GetSpaceTestAsync()
        {
            var space = await client.GetSpaceAsync();
            Assert.AreEqual(space.SpaceKey, generalConfig.SpaceKey);

            space = JsonConvert.DeserializeObject<SpaceJsonImp>(File.ReadAllText(@"TestData\space.json"));
            Assert.AreEqual(space.SpaceKey, "test-4net");
            Assert.AreEqual(space.Name, "test-4net-name");
            Assert.AreEqual(space.OwnerId, 137752L);
            Assert.AreEqual(space.Lang, "ja");
            Assert.AreEqual(space.Timezone, "Asia/Tokyo");
            Assert.AreEqual(space.ReportSendTime, "18:00:00");
            Assert.AreEqual(space.Created, new DateTime(2017, 8, 1, 7, 9, 49, DateTimeKind.Utc));
            Assert.AreEqual(space.Updated, new DateTime(2017, 8, 2, 7, 9, 49, DateTimeKind.Utc));
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

        [TestMethod]
        public async Task GetSpaceIconTestAsync()
        {
            using (var icon = await client.GetSpaceIconAsync())
            {
                Assert.IsFalse(string.IsNullOrEmpty(icon.FileName));
                byte[] iconData;
                using (var memStream = new MemoryStream())
                {
                    await icon.Content.CopyToAsync(memStream);
                    iconData = memStream.ToArray();
                }
                Assert.AreNotEqual(iconData.Length, 0);
            }            
        }
    }
}
