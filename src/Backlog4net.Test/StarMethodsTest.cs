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
    public class StarMethodsTest
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
        public async Task AddStarToIssueAndCommentAsync()
        {
            var issueTypes = await client.GetIssueTypesAsync(projectId);
            var issue = await client.CreateIssueAsync(new CreateIssueParams(projectId, "StarTestIssue", issueTypes.First().Id, IssuePriorityType.High));

            await client.AddStarToIssueAsync(issue.Id);

            var issueComment = await client.AddIssueCommentAsync(new AddIssueCommentParams(issue.Id, "Comment"));

            await client.AddStarToCommentAsync(issueComment.Id);

            await client.DeleteIssueAsync(issue.Id);
        }

        [TestMethod]
        public async Task AddStarToWikiTestAsync()
        {
            var wiki = await client.CreateWikiAsync(new CreateWikiParams(projectId, "StarTest", "StarTestContent")
            {
                MailNotify = false,
            });

            await client.AddStarToWikiAsync(wiki.Id);

            await client.DeleteWikiAsync(wiki.Id, false);
        }

        [TestMethod]
        public async Task AddStarToPullRequestAndCommentTestAsync()
        {
            var gitrepos = await client.GetGitRepositoriesAsync(projectId);
            var pullRequests = await client.GetPullRequestsAsync(projectId, gitrepos.First().Id);

            await client.AddStarToPullRequestAsync(pullRequests.First().Id);

            var pullRequestComments = await client.GetPullRequestCommentsAsync(projectId, gitrepos.First().Id, pullRequests.First().Number, new QueryParams() { });

            await client.AddStarToPullRequestCommentAsync(pullRequestComments.First().Id);
        }
    }
}
