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
    public class GitPullRequestMethodsTest
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
        public async Task GetGitRepositoriesTestAsync()
        {
            var repositories = await client.GetGitRepositoriesAsync(projectId);
            Assert.AreNotEqual(repositories[0].Id, 0L);
            Assert.AreEqual(repositories[0].ProjectId, projectId);

            var repository = await client.GetGitRepositoryAsync(projectId, repositories[0].Id);
            Assert.AreEqual(repository.Id, repositories[0].Id);

            repository = JsonConvert.DeserializeObject<Repository>(File.ReadAllText(@"TestData\repository.json"), new RepositoryJsonImpl.JsonConverter());
            Assert.AreEqual(repository.Id, 16272L);
            Assert.AreEqual(repository.ProjectId, 61932L);
            Assert.AreEqual(repository.Name, "test");
            Assert.AreEqual(repository.Description, "test-description");
            Assert.AreEqual(repository.HookUrl, "test-hook-url");
            Assert.AreEqual(repository.HttpUrl, "https://test-4net.backlog.jp/git/BLG4NT/test.git");
            Assert.AreEqual(repository.SshUrl, "test-4net@test-4net.git.backlog.jp:/BLG4NT/test.git");
            Assert.AreEqual(repository.DisplayOrder, 2147483646L);
            Assert.AreEqual(repository.PushedAt, new DateTime(2017, 8, 20, 10, 29 , 8, DateTimeKind.Utc));
            Assert.AreEqual(repository.CreatedUser.Id, 137752L);
            Assert.AreEqual(repository.Created, new DateTime(2017, 8, 20, 10, 25, 48, DateTimeKind.Utc));
            Assert.AreEqual(repository.UpdatedUser.Id, 137752L);
            Assert.AreEqual(repository.Updated, new DateTime(2017, 8, 20, 10, 25, 48, DateTimeKind.Utc));
        }
    }
}
