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
        public async Task GetSpaceActivitiesTestAsync()
        {
            var activities = await client.GetSpaceActivitiesAsync();
            Assert.AreNotEqual(activities.Count, 0);

            var milestoneActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-milestone.json"), new ActivityJsonImplBase.JsonConverter());

            var milestoneCreated = (MilestoneCreatedActivity)milestoneActivities.First(x => x.Id == 18935655L);
            Assert.AreEqual(milestoneCreated.Type, ActivityType.MilestoneCreated);
            Assert.AreEqual(milestoneCreated.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(milestoneCreated.Content.Id, 75042);
            Assert.AreEqual(milestoneCreated.Content.Name, "TestMilestone");
            Assert.AreEqual(milestoneCreated.Content.Description, "TestDescription");
            Assert.AreEqual(milestoneCreated.Content.StartDate, new DateTime(2017, 7, 1));
            Assert.AreEqual(milestoneCreated.Content.ReferenceDate, new DateTime(2017, 7, 2));
            Assert.AreEqual(milestoneCreated.CreatedUser.Id, 137752L);
            Assert.AreEqual(milestoneCreated.Created, new DateTime(2017, 8, 4, 4, 3, 54, DateTimeKind.Utc));

            var milestoneUpdated = (MilestoneUpdatedActivity)milestoneActivities.First(x => x.Id == 18935657);
            Assert.AreEqual(milestoneUpdated.Type, ActivityType.MilestoneUpdated);
            Assert.AreEqual(milestoneUpdated.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(milestoneUpdated.Content.Id, 75042);
            Assert.AreEqual(milestoneUpdated.Content.Name, "TestMilestoneUpdate");
            Assert.IsTrue(milestoneUpdated.Content.Changes.Any(x => x.Field == "name" && x.NewValue == "TestMilestoneUpdate" && x.OldValue == "TestMilestone"));
            Assert.IsTrue(milestoneUpdated.Content.Changes.Any(x => x.Field == "startDate" && x.NewValue == "2017-07-11" && x.OldValue == "2017-07-01"));
            Assert.IsTrue(milestoneUpdated.Content.Changes.Any(x => x.Field == "referenceDate" && x.NewValue == "" && x.OldValue == "2017-07-02"));
            Assert.IsTrue(milestoneUpdated.Content.Changes.Any(x => x.Field == "description" && x.NewValue == "TestDescriptionUpdated" && x.OldValue == "TestDescription"));
            Assert.AreEqual(milestoneUpdated.CreatedUser.Id, 137752L);
            Assert.AreEqual(milestoneUpdated.Created, new DateTime(2017, 8, 4, 4, 3, 54, DateTimeKind.Utc));

            var milestoneDeleted = (MilestoneDeletedActivity)milestoneActivities.First(x => x.Id == 18935658L);
            Assert.AreEqual(milestoneDeleted.Type, ActivityType.MilestoneDeleted);
            Assert.AreEqual(milestoneDeleted.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(milestoneDeleted.Content.Id, 75042);
            Assert.AreEqual(milestoneDeleted.Content.Name, "TestMilestoneUpdate");
            Assert.AreEqual(milestoneDeleted.Content.Description, "TestDescriptionUpdated");
            Assert.AreEqual(milestoneDeleted.Content.StartDate, new DateTime(2017, 7, 11));
            Assert.AreEqual(milestoneDeleted.Content.ReferenceDate, null);
            Assert.AreEqual(milestoneDeleted.CreatedUser.Id, 137752L);
            Assert.AreEqual(milestoneDeleted.Created, new DateTime(2017, 8, 4, 4, 3, 54, DateTimeKind.Utc));

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

        [TestMethod]
        public async Task GetSpaceDiskUsageTestAsync()
        {
            var diskUsage = await client.GetSpaceDiskUsageAsync();
            Assert.AreNotEqual(diskUsage.Capacity, 0L);

            diskUsage = JsonConvert.DeserializeObject<DiskUsageJsonImpl>(File.ReadAllText(@"TestData\space-diskUsage.json"));
            Assert.AreEqual(diskUsage.Capacity, 107374182400L);
            Assert.AreEqual(diskUsage.Issue, 10L);
            Assert.AreEqual(diskUsage.Wiki, 20L);
            Assert.AreEqual(diskUsage.File, 21430L);
            Assert.AreEqual(diskUsage.Subversion, 30L);
            Assert.AreEqual(diskUsage.Git, 40L);
            Assert.AreEqual(diskUsage.Details[0].ProjectId, 61932L);
            Assert.AreEqual(diskUsage.Details[0].Issue, 1L);
            Assert.AreEqual(diskUsage.Details[0].Wiki, 2L);
            Assert.AreEqual(diskUsage.Details[0].File, 21430L);
            Assert.AreEqual(diskUsage.Details[0].Subversion, 3L);
            Assert.AreEqual(diskUsage.Details[0].Git, 4L);
        }
    }
}
