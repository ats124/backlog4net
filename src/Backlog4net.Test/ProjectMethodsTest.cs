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
        public async Task ProjectAsyncTest()
        {
            var project = await client.CreateProjectAsync(new CreateProjectParams("TestProject", "TESTPRJ", true, true, TextFormattingRule.Backlog));
            Assert.AreEqual(project.Name, "TestProject");
            Assert.AreEqual(project.ProjectKey, "TESTPRJ");
            Assert.AreEqual(project.IsChartEnabled, true);
            Assert.AreEqual(project.IsSubtaskingEnabled, true);
            Assert.AreEqual(project.TextFormattingRule, TextFormattingRule.Backlog);

            var updatedProject = await client.UpdateProjectAsync(new UpdateProjectParams(project.Id)
            {
                Name = "TestProjectUpdated",
                ChartEnabled = false,
                SubtaskingEnabled = false,
                TextFormattingRule = TextFormattingRule.Markdown,
                Archived = true,
                ProjectKey = "TESTPRJU",
            });
            Assert.AreEqual(updatedProject.Name, "TestProjectUpdated");
            Assert.AreEqual(updatedProject.ProjectKey, "TESTPRJU");
            Assert.AreEqual(updatedProject.IsChartEnabled, false);
            Assert.AreEqual(updatedProject.IsSubtaskingEnabled, false);
            Assert.AreEqual(updatedProject.TextFormattingRule, TextFormattingRule.Markdown);
            Assert.AreEqual(updatedProject.IsArchived, true);

            var projects = await client.GetProjectsAsync();
            Assert.IsTrue(projects.Any(x => x.Id == updatedProject.Id && x.Name == "TestProjectUpdated"));

            var deletedProject = await client.DeleteProjectAsync(updatedProject.Id);
            Assert.AreEqual(deletedProject.Id, updatedProject.Id);
            Assert.AreEqual(deletedProject.Name, updatedProject.Name);

            projects = await client.GetProjectsAsync();
            Assert.IsFalse(projects.Any(x => x.Id == updatedProject.Id && x.Name == "TestProjectUpdated"));
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

        [TestMethod]
        public async Task SharedFileAsyncTest()
        {
            var sharedFiles = await client.GetSharedFilesAsync(generalConfig.ProjectKey, projectConfig.SharedFileDirectory, new QueryParams() { Count = 1, Order = Order.Asc });
            Assert.AreEqual(sharedFiles.Count, 1);

            sharedFiles = await client.GetSharedFilesAsync(generalConfig.ProjectKey, projectConfig.SharedFileDirectory);
            var sharedFile1 = sharedFiles.First(x => x.Name == projectConfig.SharedFile1);
            Assert.IsTrue(sharedFile1.Dir.Contains(projectConfig.SharedFileDirectory));
            Assert.AreNotEqual(sharedFile1.Size, 0L);

            var created = sharedFile1.Created.Value;
            created = new DateTime(created.Year, created.Month, created.Day, created.Hour, created.Minute, 0);
            var checkCreated = projectConfig.SharedFile1Created.ToUniversalTime();
            checkCreated = new DateTime(checkCreated.Year, checkCreated.Month, checkCreated.Day, checkCreated.Hour, checkCreated.Minute, 0);
            Assert.AreEqual(created, checkCreated);

            var sharedImageFile1 = sharedFiles.First(x => x.Name == projectConfig.SharedImageFile1);
            Assert.IsTrue(sharedImageFile1.IsImage);

            var memStream = new System.IO.MemoryStream();
            using (var sharedFile1Data = await client.DownloadSharedFileAsync(generalConfig.ProjectKey, sharedFile1.Id))
            {
                Assert.AreEqual(sharedFile1Data.FileName, projectConfig.SharedFile1);
                memStream.SetLength(0);
                await sharedFile1Data.Content.CopyToAsync(memStream);
                Assert.AreEqual(memStream.Length, sharedFile1.Size);
            }
        }

        [TestMethod]
        public async Task ProjectIconTest()
        {
            var memStream = new System.IO.MemoryStream();
            using (var icon = await client.GetProjectIconAsync(generalConfig.ProjectKey))
            {
                Assert.IsFalse(string.IsNullOrEmpty(icon.FileName));
                await icon.Content.CopyToAsync(memStream);
                Assert.AreNotEqual(memStream.Length, 0);
            }
        }

        [TestMethod]
        public async Task ProjectActivitiesIssueTestAsync()
        {
            await ProjectUserAsyncTest();
            var activities = await client.GetProjectActivitiesAsync(generalConfig.ProjectKey, new ActivityQueryParams() { ActivityType = new[] { ActivityType.ProjectUserAdded, ActivityType.ProjectUserRemoved } });
            Assert.IsTrue(activities.Count > 0);
            activities.Any(x => x.Type == ActivityType.ProjectUserAdded);
            activities.Any(x => x.Type == ActivityType.ProjectUserRemoved);

            var issueActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-issue.json"), new ActivityJsonImplBase.JsonConverter());

            var issueCreated = (IssueCreatedActivity)issueActivities.First(x => x.Id == 18059501);
            Assert.AreEqual(issueCreated.Type, ActivityType.IssueCreated);
            Assert.AreEqual(issueCreated.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(issueCreated.Content.Id, 2670276L);
            Assert.AreEqual(issueCreated.Content.KeyId, 1L);
            Assert.AreEqual(issueCreated.Content.Summary, "TestIssueCreatedSummary");
            Assert.AreEqual(issueCreated.Content.Description, "TestIssueCreatedDescription\n");
            Assert.AreEqual(issueCreated.CreatedUser.Id, 127017L);
            Assert.AreEqual(issueCreated.Created, new DateTime(2017, 7, 23, 6, 29, 35, DateTimeKind.Utc));

            var issueUpdated = (IssueUpdatedActivity)issueActivities.First(x => x.Id == 18059594);
            Assert.AreEqual(issueUpdated.Type, ActivityType.IssueUpdated);
            Assert.AreEqual(issueUpdated.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(issueUpdated.Content.Id, 2670276L);
            Assert.AreEqual(issueUpdated.Content.KeyId, 1L);
            Assert.AreEqual(issueUpdated.Content.Summary, "TestIssueCreatedSummaryUpdated");
            Assert.AreEqual(issueUpdated.Content.Description, "TestIssueCreatedDescriptionUpdated\n");
            Assert.AreEqual(issueUpdated.Content.Comment.Id, 12748076L);
            Assert.AreEqual(issueUpdated.Content.Comment.Content, "TestIssueCreatedComment");
            Assert.AreEqual(issueUpdated.Content.Changes[0].Field, "attachment");
            Assert.AreEqual(issueUpdated.Content.Changes[0].NewValue, "TestFile3.txt");
            Assert.AreEqual(issueUpdated.Content.Changes[0].OldValue, "");
            Assert.AreEqual(issueUpdated.Content.Changes[0].Type, "standard");
            Assert.AreEqual(issueUpdated.Content.Attachments[0].Id, 1283213L);
            Assert.AreEqual(issueUpdated.Content.Attachments[0].Name, "TestFile3.txt");
            Assert.AreEqual(issueUpdated.Content.Attachments[0].Size, 12L);

            var issueCommented = (IssueCommentedActivity)issueActivities.First(x => x.Id == 18060339);
            Assert.AreEqual(issueCommented.Type, ActivityType.IssueCommented);
            Assert.AreEqual(issueCommented.Project.ProjectKey, "BLG4NT");
            Assert.AreEqual(issueCommented.Content.Id, 2670276L);
            Assert.AreEqual(issueCommented.Content.KeyId, 1L);
            Assert.AreEqual(issueCommented.Content.Summary, "TestIssueCreatedSummaryUpdated");
            Assert.AreEqual(issueCommented.Content.Description, "TestIssueCreatedDescriptionUpdated\n");
            Assert.AreEqual(issueCommented.Content.Comment.Id, 12748626L);
            Assert.AreEqual(issueCommented.Content.Comment.Content, "IssueCommentTest");
            Assert.AreEqual(issueCommented.Content.Changes[0].Field, "attachment");
            Assert.AreEqual(issueCommented.Content.Changes[0].NewValue, "TestFile3.txt");
            Assert.AreEqual(issueCommented.Content.Changes[0].OldValue, "");
            Assert.AreEqual(issueCommented.Content.Changes[0].Type, "standard");
            Assert.AreEqual(issueCommented.Content.Attachments[0].Id, 1283270L);
            Assert.AreEqual(issueCommented.Content.Attachments[0].Name, "TestFile3.txt");
            Assert.AreEqual(issueCommented.Content.Attachments[0].Size, 12L);

            var issueDeleted = (IssueDeletedActivity)issueActivities.First(x => x.Id == 18060490);
            Assert.AreEqual(issueDeleted.Type, ActivityType.IssueDeleted);
            Assert.AreEqual(issueDeleted.Content.Id, 2670276L);
            Assert.AreEqual(issueDeleted.Content.KeyId, 1L);

            var issueMultiUpdated = (IssueMultiUpdatedActivity)issueActivities.First(x => x.Id == 18061933);
            Assert.AreEqual(issueMultiUpdated.Type, ActivityType.IssueMultiUpdated);
            Assert.AreEqual(issueMultiUpdated.Content.TxId, 87469L);
            Assert.AreEqual(issueMultiUpdated.Content.Comment.Content, "IssueMultiUpdatedTestComment");
            Assert.AreEqual(issueMultiUpdated.Content.Link[0].Id, 2670780L);
            Assert.AreEqual(issueMultiUpdated.Content.Link[0].KeyId, 2L);
            Assert.AreEqual(issueMultiUpdated.Content.Link[0].Title, "IssueMultiUpdatedTestSummary1");
            Assert.AreEqual(issueMultiUpdated.Content.Link[1].Id, 2670781L);
            Assert.AreEqual(issueMultiUpdated.Content.Link[1].KeyId, 3L);
            Assert.AreEqual(issueMultiUpdated.Content.Link[1].Title, "IssueMultiUpdatedTestSummary2");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[0].Field, "milestone");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[0].NewValue, "TestM");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[0].Type, "standard");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[1].Field, "limitDate");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[1].NewValue, "2017/07/23");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[1].Type, "standard");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[2].Field, "assigner");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[2].NewValue, "ats124");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[2].Type, "standard");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[3].Field, "resolution");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[3].NewValue, "0");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[3].Type, "standard");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[4].Field, "status");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[4].NewValue, "4");
            Assert.AreEqual(issueMultiUpdated.Content.Changes[4].Type, "standard");

        }

        [TestMethod]
        public void ProjectActivitiesWikiTest()
        {
            var wikiActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-wiki.json"), new ActivityJsonImplBase.JsonConverter());

            var wikiCreated = (WikiCreatedActivity)wikiActivities.First(x => x.Id == 18062171);
            Assert.AreEqual(wikiCreated.Type, ActivityType.WikiCreated);
            Assert.AreEqual(wikiCreated.Content.Id, 177370L);
            Assert.AreEqual(wikiCreated.Content.Name, "WikiCreatedTestTitle");
            Assert.AreEqual(wikiCreated.Content.Content, "WikiCreatedContent");

            var wikiUpdated = (WikiUpdatedActivity)wikiActivities.First(x => x.Id == 18062174);
            Assert.AreEqual(wikiUpdated.Type, ActivityType.WikiUpdated);
            Assert.AreEqual(wikiUpdated.Content.Id, 177370L);
            Assert.AreEqual(wikiUpdated.Content.Name, "WikiCreatedTestTitleUpdated");
            Assert.AreEqual(wikiUpdated.Content.Content, "WikiCreatedContentUpdated");
            Assert.AreEqual(wikiUpdated.Content.Diff, "1c1\n<WikiCreatedContentUpdated---\n>WikiCreatedContent");
            Assert.AreEqual(wikiUpdated.Content.Version, 2);

            var wikiUpdated2 = (WikiUpdatedActivity)wikiActivities.First(x => x.Id == 18062278);
            Assert.AreEqual(wikiUpdated2.Content.Attachments[0].Id, 46346L);
            Assert.AreEqual(wikiUpdated2.Content.Attachments[0].Name, "TestFile3.txt");
            Assert.AreEqual(wikiUpdated2.Content.Attachments[0].Size, 12L);

            var wikiDeleted = (WikiDeletedActivity)wikiActivities.First(x => x.Id == 18062177);
            Assert.AreEqual(wikiDeleted.Type, ActivityType.WikiDeleted);
            Assert.AreEqual(wikiDeleted.Content.Name, "WikiCreatedTestTitleUpdated");
            Assert.AreEqual(wikiDeleted.Content.Content, "WikiCreatedContentUpdated");
        }

        [TestMethod]
        public void ProjectActivitiesFileTest()
        {
            var fileActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-file.json"), new ActivityJsonImplBase.JsonConverter());

            var fileAdded = (FileAddedActivity)fileActivities.First(x => x.Id == 18109978);
            Assert.AreEqual(fileAdded.Type, ActivityType.FileAdded);
            Assert.AreEqual(fileAdded.Content.Id, 1957758L);
            Assert.AreEqual(fileAdded.Content.Dir, "/テストディレクトリ１/");
            Assert.AreEqual(fileAdded.Content.Name, "TestFile3.txt");
            Assert.AreEqual(fileAdded.Content.Size, 12);

            var fileUpdated = (FileUpdatedActivity)fileActivities.First(x => x.Id == 18110130);
            Assert.AreEqual(fileUpdated.Type, ActivityType.FileUpdated);
            Assert.AreEqual(fileUpdated.Content.Id, 1957758L);
            Assert.AreEqual(fileUpdated.Content.Dir, "/テストディレクトリ１/");
            Assert.AreEqual(fileUpdated.Content.Name, "TestFile4.txt");
            Assert.AreEqual(fileUpdated.Content.Size, 17);

            var fileDeleted = (FileDeletedActivity)fileActivities.First(x => x.Id == 18110161);
            Assert.AreEqual(fileDeleted.Type, ActivityType.FileDeleted);
            Assert.AreEqual(fileDeleted.Content.Id, 1957758L);
            Assert.AreEqual(fileDeleted.Content.Dir, "/テストディレクトリ１/");
            Assert.AreEqual(fileDeleted.Content.Name, "TestFile4.txt");
            Assert.AreEqual(fileDeleted.Content.Size, 17);
        }

        [TestMethod]
        public void ProjectActivitiesSvnTest()
        {
            var svnActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-svn.json"), new ActivityJsonImplBase.JsonConverter());

            var svnComitted = (SvnCommittedActivity)svnActivities.First(x => x.Id == 18152632);
            Assert.AreEqual(svnComitted.Type, ActivityType.SvnCommitted);
            Assert.AreEqual(svnComitted.Content.Rev, 2L);
            Assert.AreEqual(svnComitted.Content.Comment, "Test Commit 2");

        }

        [TestMethod]
        public void ProjectActivitiesGitTest()
        {
            var gitActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-git.json"), new ActivityJsonImplBase.JsonConverter());

            var gitPushed = (GitPushedActivity)gitActivities.First(x => x.Id == 18153475);
            Assert.AreEqual(gitPushed.Type, ActivityType.GitPushed);
            Assert.AreEqual(gitPushed.Content.Repository.Id, 15203L);
            Assert.AreEqual(gitPushed.Content.Repository.Name, "test");
            Assert.AreEqual(gitPushed.Content.ChangeType, "create");
            Assert.AreEqual(gitPushed.Content.RevisionType, "commit");
            Assert.AreEqual(gitPushed.Content.Ref, "refs/heads/master");
            Assert.AreEqual(gitPushed.Content.RevisionCount, 1);
            Assert.AreEqual(gitPushed.Content.Revisions[0].Rev, "640cce73754865ae856fc1c9b31ab7eed8c321cd");
            Assert.AreEqual(gitPushed.Content.Revisions[0].Comment, "test commit");

            var gitRepoCreated = (GitRepositoryCreatedActivity)gitActivities.First(x => x.Id == 18153443);
            Assert.AreEqual(gitRepoCreated.Type, ActivityType.GitRepositoryCreated);
            Assert.AreEqual(gitRepoCreated.Content.Repository.Id, 15203L);
            Assert.AreEqual(gitRepoCreated.Content.Repository.Name, "test");
            Assert.AreEqual(gitRepoCreated.Content.Repository.Description, "test repository");
        }

    }
}
