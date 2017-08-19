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
    public class WatchingMethodsTest
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
        public async Task WatchingTestAsync()
        {
            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "WatchingTestIssue", issueTypes.First().Id, IssuePriorityType.High));

            var watch = await client.AddWatchToIssueAsync(issue.Id, "Note");
            Assert.AreNotEqual(watch.Id, 0);
            Assert.AreEqual(watch.Issue.Id, issue.Id);
            Assert.AreEqual(watch.Note, "Note");
            Assert.IsNotNull(watch.Created);
            Assert.IsNotNull(watch.Updated);

            await client.MarkAsCheckedUserWatchesAsync(ownUser.Id);

            var watchGet = await client.GetWatchAsync(watch.Id);
            Assert.AreEqual(watchGet.Id, watch.Id);
            Assert.AreEqual(watchGet.Note, watch.Note);
            Assert.AreEqual(watchGet.Issue.Id, watch.Issue.Id);

            var watchUpdated = await client.UpdateWatchAsync(new UpdateWatchParams(watch.Id) { Note = "NoteUpdated" });
            Assert.AreEqual(watchUpdated.Id, watch.Id);
            Assert.AreEqual(watchUpdated.Note, "NoteUpdated");

            var watchDeleted =  await client.DeleteWatchAsync(watch.Id);
            Assert.AreEqual(watchDeleted.Id, watchUpdated.Id);
            Assert.AreEqual(watchDeleted.Note, watchUpdated.Note);

            await client.DeleteIssueAsync(issue.Id);
        }
    }
}
