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
    public class ImportMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static long projectId;
        private static User anotherUser;
        private static IList<IssueType> issueTypes;

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
            issueTypes = await client.GetIssueTypesAsync(projectId);

            var conf2 = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf2.ApiKey = generalConfig.ApiKey2;
            var client2 = new BacklogClientFactory(conf).NewClient();
            anotherUser = await client2.GetMyselfAsync();
        }

        [TestMethod]
        public async Task ImportTestAsync()
        {
            var issue = await client.ImportIssueAsync(new ImportIssueParams(projectId, "ImportTest", issueTypes.First().Id, IssuePriorityType.High)
            {
                Description = "Description",
                CreatedUserId = anotherUser.Id,
                Created = new DateTime(2017, 8, 1, 10, 5, 10, DateTimeKind.Utc),
            });
            Assert.AreEqual(issue.Description, "Description");
            Assert.AreEqual(issue.CreatedUser.Id, anotherUser.Id);
            Assert.AreEqual(issue.Created, new DateTime(2017, 8, 1, 10, 5, 10, DateTimeKind.Utc));

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public async Task ImportUpdateTestAsync()
        {
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "ImportUpdatedTest", issueTypes.First().Id, IssuePriorityType.High));
            var issueUpdated = await client.ImportUpdateIssueAsync(new ImportUpdateIssueParams(issue.Id)
            {
                Summary = "ImportUpdatedTestUpdated",
                UpdatedUserId = anotherUser.Id,
                Updated = new DateTime(2017, 8, 2, 10, 5, 10, DateTimeKind.Utc),
            });
            Assert.AreEqual(issueUpdated.UpdatedUser.Id, anotherUser.Id);
            Assert.AreEqual(issueUpdated.Updated, new DateTime(2017, 8, 2, 10, 5, 10, DateTimeKind.Utc));

            await client.DeleteIssueAsync(issue.Id);
        }
    }
}
