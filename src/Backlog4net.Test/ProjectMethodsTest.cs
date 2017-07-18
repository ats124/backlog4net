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

        [TestMethod]
        public async Task MilestoneAsyncTest()
        {
            var milestone = await client.AddMilestoneAsync(
                new AddMilestoneParams(generalConfig.ProjectKey, "TestMilestone")
                {
                    StartDate = new DateTime(2017, 7, 1),
                    ReleaseDueDate = new DateTime(2017, 7, 2),
                    Description = "TestDescription",
                });
            Assert.AreEqual(milestone.Name, "TestMilestone");
            Assert.AreEqual(milestone.StartDate, new DateTime(2017, 7, 1));
            Assert.AreEqual(milestone.ReleaseDueDate, new DateTime(2017, 7, 2));
            Assert.AreEqual(milestone.Description, "TestDescription");

            var updatedMilestone = await client.UpdateMilestoneAsync(
                new UpdateMilestoneParams(generalConfig.ProjectKey, milestone.Id, "TestMilestoneUpdate")
                {
                    StartDate = new DateTime(2017, 7, 11),
                    ReleaseDueDate = null,
                    Description = "TestDescriptionUpdated",
                });
            Assert.AreEqual(updatedMilestone.StartDate, new DateTime(2017, 7, 11));
            Assert.IsNull(updatedMilestone.ReleaseDueDate);

            var milestones = await client.GetMilestonesAsync(generalConfig.ProjectKey);
            Assert.IsTrue(milestones.Any(x => x.Id == updatedMilestone.Id && x.Name == updatedMilestone.Name));

            var deletedMilestone = await client.RemoveMilestoneAsync(generalConfig.ProjectKey, updatedMilestone.Id);
            Assert.AreEqual(deletedMilestone.Id, updatedMilestone.Id);
            Assert.AreEqual(deletedMilestone.Name, updatedMilestone.Name);

            milestones = await client.GetMilestonesAsync(generalConfig.ProjectKey);
            Assert.IsFalse(milestones.Any(x => x.Id == updatedMilestone.Id && x.Name == updatedMilestone.Name));
        }

        [TestMethod]
        public async Task VersionAsyncTest()
        {
            var version = await client.AddVersionAsync(
                new AddVersionParams(generalConfig.ProjectKey, "TestVersion")
                {
                    StartDate = new DateTime(2017, 7, 1),
                    ReleaseDueDate = null,
                    Description = "TestDescription",
                });
            Assert.AreEqual(version.Name, "TestVersion");
            Assert.AreEqual(version.StartDate, new DateTime(2017, 7, 1));
            Assert.IsNull(version.ReleaseDueDate);
            Assert.AreEqual(version.Description, "TestDescription");

            var updatedVersion = await client.UpdateVersionAsync(
                new UpdateVersionParams(generalConfig.ProjectKey, version.Id, "TestMilestoneUpdate")
                {
                    StartDate = null,
                    ReleaseDueDate = new DateTime(2017, 7, 12),
                    Description = "TestDescriptionUpdated",
                });
            Assert.IsNull(updatedVersion.StartDate);
            Assert.AreEqual(updatedVersion.ReleaseDueDate, new DateTime(2017, 7, 12));
            Assert.AreEqual(updatedVersion.Description, "TestDescriptionUpdated");

            var versions = await client.GetVersionsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(versions.Any(x => x.Id == updatedVersion.Id && x.Name == updatedVersion.Name));

            var deletedVersion = await client.RemoveMilestoneAsync(generalConfig.ProjectKey, updatedVersion.Id);
            Assert.AreEqual(deletedVersion.Id, updatedVersion.Id);
            Assert.AreEqual(deletedVersion.Name, updatedVersion.Name);

            versions = await client.GetVersionsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(versions.Any(x => x.Id == updatedVersion.Id && x.Name == updatedVersion.Name));
        }
    }
}
