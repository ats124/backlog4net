using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api;
    using Api.Option;
    using Conf;
    using TestConfig;

    [TestClass]
    public class ProjectMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static ProjectsConfig projectConfig;
        private static long numericAnotherUserId;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            projectConfig = ProjectsConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();
            var users = await client.GetUsersAsync();
            numericAnotherUserId = users.First(x => x.UserId == projectConfig.AnotherUserId).Id;
        }

        [TestMethod]
        public async Task GetProjectsAsyncTest()
        {
            var projects = await client.GetProjectsAsync();
            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count > 0);
            Assert.IsFalse(string.IsNullOrEmpty(projects[0].Name));
        }

        [TestMethod]
        public async Task ProjectUserAsyncTest()
        {
            var user = await client.AddProjectUserAsync(generalConfig.ProjectKey, numericAnotherUserId);
            Assert.AreEqual(user.UserId, projectConfig.AnotherUserId);
            Assert.IsFalse(string.IsNullOrEmpty(user.Name));
            Assert.IsFalse(string.IsNullOrEmpty(user.MailAddress));

            var users = await client.GetProjectUsersAsync(generalConfig.ProjectKey);
            Assert.IsTrue(users.Count > 1);
            Assert.IsTrue(users.Any(x => x.Id == numericAnotherUserId && x.UserId == projectConfig.AnotherUserId));

            var deleteUser = await client.RemoveProjectUserAsync(generalConfig.ProjectKey, numericAnotherUserId);
            Assert.AreEqual(deleteUser.UserId, projectConfig.AnotherUserId);

            users = await client.GetProjectUsersAsync(generalConfig.ProjectKey);
            Assert.IsFalse(users.Any(x => x.Id == numericAnotherUserId && x.UserId == projectConfig.AnotherUserId));
        }

        [TestMethod]
        public async Task CategoryAsyncTest()
        {
            var category = await client.AddCategoryAsync(new AddCategoryParams(generalConfig.ProjectKey, "TestCategory"));
            Assert.AreEqual(category.Name, "TestCategory");
            Assert.AreNotEqual(category.Id, 0L);

            var updatedCategory = await client.UpdateCategoryAsync(new UpdateCategoryParams(generalConfig.ProjectKey, category.Id, "TestCategoryUpdated"));
            Assert.AreEqual(updatedCategory.Name, "TestCategoryUpdated");
            Assert.AreEqual(updatedCategory.Id, category.Id);

            var categories = await client.GetCategoriesAsync(generalConfig.ProjectKey);
            Assert.IsTrue(categories.Any(x => x.Id == updatedCategory.Id && x.Name == updatedCategory.Name));

            var deletedCategory = await client.RemoveCategoryAsync(generalConfig.ProjectKey, updatedCategory.Id);
            Assert.AreEqual(deletedCategory.Id, updatedCategory.Id);
            Assert.AreEqual(deletedCategory.Name, updatedCategory.Name);

            categories = await client.GetCategoriesAsync(generalConfig.ProjectKey);
            Assert.IsFalse(categories.Any(x => x.Id == updatedCategory.Id && x.Name == updatedCategory.Name));
        }
    }
}
