﻿using System;
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

        [TestMethod]
        public async Task GetUserIconTestAsync()
        {
            var ownuser = await client.GetMyselfAsync();
            using (var icon = await client.GetUserIconAsync(ownuser.Id))
            using (var content = icon.Content)
            {
                var memstream = new MemoryStream();
                await content.CopyToAsync(memstream);
                Assert.AreNotEqual(memstream.Length, 0);
            }
        }

        [TestMethod]
        public async Task GetUserActivitiesTestAsync()
        {
            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "GetUserActivitiesTest", issueTypes.First().Id, IssuePriorityType.High));
            await client.DeleteIssueAsync(issue.Id);

            var ownuser = await client.GetMyselfAsync();
            var activities = await client.GetUserActivitiesAsync(ownuser.Id, new ActivityQueryParams() { ActivityType = new[] { ActivityType.IssueCreated } });
            Assert.IsTrue(activities.Any(x => x is IssueCreatedActivity issueCreated && issueCreated.Content.Id == issue.Id));

        }

        [TestMethod]
        public async Task GetUserStarsAndCountTestAsync()
        {
            var ownuser = await client.GetMyselfAsync();

            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "GetUsersStarsTest", issueTypes.First().Id, IssuePriorityType.High));

            await client.AddStarToIssueAsync(issue.Id);

            var count = await client.GetUserStarCountAsync(ownuser.Id, new GetStarsParams() { Since = DateTime.UtcNow.AddDays(-1).Date, Until = DateTime.UtcNow.Date });
            Assert.IsTrue(count > 0);

            var stars = await client.GetUserStarsAsync(ownuser.Id, new QueryParams() { Count = 1, Order = Order.Asc });
            Assert.IsTrue(stars.Any());

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public async Task GetRecentlyViewedIssuesTestAsync()
        {
            await client.GetRecentlyViewedIssuesAsync(new OffsetParams() { Count = 1, Offset = 2, Order = Order.Asc });

            var viewedIssues = JsonConvert.DeserializeObject<ViewedIssue[]>(File.ReadAllText(@"TestData\viewed-issues.json"), new ViewedIssueJsonImpl.JsonConverter());
            Assert.AreEqual(viewedIssues[0].Issue.Id, 2941432L);
            Assert.AreEqual(viewedIssues[0].Updated, new DateTime(2017, 8, 20, 4, 2, 27, DateTimeKind.Utc));
        }

        [TestMethod]
        public async Task GetRecentlyViewedProjectsTestAsync()
        {
            await client.GetRecentlyViewedProjectsAsync(new OffsetParams() { Count = 1, Offset = 2, Order = Order.Asc });

            var viewedProjects = JsonConvert.DeserializeObject<ViewedProject[]>(File.ReadAllText(@"TestData\viewed-projects.json"), new ViewedProjectJsonImpl.JsonConverter());
            Assert.AreEqual(viewedProjects[0].Project.Id, 61932L);
            Assert.AreEqual(viewedProjects[0].Updated, new DateTime(2017, 8, 1, 7, 56, 12, DateTimeKind.Utc));
        }

        [TestMethod]
        public async Task GetRecentlyViewedWikisTestAsync()
        {
            await client.GetRecentlyViewedWikisAsync(new OffsetParams() { Count = 1, Offset = 2, Order = Order.Asc });

            var viewedWikis = JsonConvert.DeserializeObject<ViewedWiki[]>(File.ReadAllText(@"TestData\viewed-wikis.json"), new ViewedWikiJsonImpl.JsonConverter());
            Assert.AreEqual(viewedWikis[0].Page.Id, 182111L);
            Assert.AreEqual(viewedWikis[0].Updated, new DateTime(2017, 8, 15, 17, 6, 6, DateTimeKind.Utc));
        }

        [TestMethod]
        public async Task UserWatchsAndCountTestAsync()
        {
            var ownuser = await client.GetMyselfAsync();

            await client.GetUserWatchCountAsync(ownuser.Id, new GetWatchCountParams() { AlreadyRead = true });
            await client.GetUserWatchCountAsync(ownuser.Id, new GetWatchCountParams() { ResourceAlreadyRead = true });

            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "WatchingTestIssue", issueTypes.First().Id, IssuePriorityType.High));

            var watch = await client.AddWatchToIssueAsync(issue.Id, "Note");

            var count = await client.GetUserWatchCountAsync(ownuser.Id);
            Assert.AreNotEqual(count, 0);

            var watches = await client.GetUserWatchesAsync(ownuser.Id, new GetWatchesParams()
            {
                Count = 100,
                ResourceAlreadyRead = true,
                Sort = GetWatchsSortKey.Created,
                Order = Order.Asc,
                IssueIds = new[] { issue.Id }
            });
            //Assert.IsTrue(watches.Any(x => x.Issue.Id == issue.Id));

            await client.DeleteIssueAsync(issue.Id);
        }
    }
}
