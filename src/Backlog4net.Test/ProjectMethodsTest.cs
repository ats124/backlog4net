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

        [TestMethod]
        public void ProjectActivitiesUserTest()
        {
            var userActivities = JsonConvert.DeserializeObject<Activity[]>(File.ReadAllText(@"TestData\activity-user.json"), new ActivityJsonImplBase.JsonConverter());

            var userAdded = (ProjectUserAddedActivity)userActivities.First(x => x.Id == 18062024);
            Assert.AreEqual(userAdded.Type, ActivityType.ProjectUserAdded);
            Assert.AreEqual(userAdded.Content.Users[0].Id, 128937L);
            Assert.AreEqual(userAdded.Content.Users[0].UserId, "ats124_2");
            Assert.AreEqual(userAdded.Content.Users[0].RoleType, UserRoleType.User);
            Assert.AreEqual(userAdded.Content.Users[0].MailAddress, "ats124+2@section-9.tech");

            var userRemoved = (ProjectUserRemovedActivity)userActivities.First(x => x.Id == 18062025);
            Assert.AreEqual(userRemoved.Type, ActivityType.ProjectUserRemoved);
            Assert.AreEqual(userRemoved.Content.Users[0].Id, 128937L);
            Assert.AreEqual(userRemoved.Content.Users[0].UserId, "ats124_2");
            Assert.AreEqual(userRemoved.Content.Users[0].RoleType, UserRoleType.User);
            Assert.AreEqual(userRemoved.Content.Users[0].MailAddress, "ats124+2@section-9.tech");

        }

        [TestMethod]
        public async Task IssueTypeTestAsync()
        {
            var issueType = await client.AddIssueTypeAsync(new AddIssueTypeParams(generalConfig.ProjectKey, "TestIssueType", IssueTypeColors.Color10));
            Assert.AreNotEqual(issueType.ProjectId, 0L);
            Assert.AreNotEqual(issueType.Id, 0L);
            Assert.AreEqual(issueType.Name, "TestIssueType");
            Assert.AreEqual(issueType.Color, IssueTypeColors.Color10);

            var updatedIssueType = await client.UpdateIssueTypeAsync(new UpdateIssueTypeParams(generalConfig.ProjectKey, issueType.Id) { Name = "TestIssueTypeUpdated", Color = IssueTypeColors.Color5 });
            Assert.AreNotEqual(updatedIssueType.ProjectId, 0L);
            Assert.AreEqual(updatedIssueType.Id, issueType.Id);
            Assert.AreEqual(updatedIssueType.Name, "TestIssueTypeUpdated");
            Assert.AreEqual(updatedIssueType.Color, IssueTypeColors.Color5);

            var issueTypes = await client.GetIssueTypesAsync(generalConfig.ProjectKey);
            Assert.IsTrue(issueTypes.Any(x => x.Id == updatedIssueType.Id && x.Name == updatedIssueType.Name));

            var substituteIssueTypeId = issueTypes.First(x => x.Id != updatedIssueType.Id).Id;
            var removedIssueType = await client.RemoveIssueTypeAsync(generalConfig.ProjectKey, updatedIssueType.Id, substituteIssueTypeId);
            Assert.AreNotEqual(removedIssueType.ProjectId, 0L);
            Assert.AreEqual(removedIssueType.Id, issueType.Id);
            Assert.AreEqual(removedIssueType.Name, "TestIssueTypeUpdated");
            Assert.AreEqual(removedIssueType.Color, IssueTypeColors.Color5);

            issueTypes = await client.GetIssueTypesAsync(generalConfig.ProjectKey);
            Assert.IsFalse(issueTypes.Any(x => x.Id == updatedIssueType.Id));
        }

        [TestMethod]
        public async Task GetProjectDiskUsageTestAsync()
        {
            var diskUsage = await client.GetProjectDiskUsageAsync(generalConfig.ProjectKey);
            Assert.AreNotEqual(diskUsage.ProjectId, 0L);

            diskUsage = JsonConvert.DeserializeObject<DiskUsageDetail>(File.ReadAllText(@"TestData\diskUsage.json"), new DiskUsageDetailJsonImpl.JsonConverter());
            Assert.AreEqual(diskUsage.Issue, 1L);
            Assert.AreEqual(diskUsage.Wiki, 2L);
            Assert.AreEqual(diskUsage.File, 3L);
            Assert.AreEqual(diskUsage.Subversion, 4L);
            Assert.AreEqual(diskUsage.Git, 5L);
        }

        [TestMethod]
        public async Task AdministratorTestAsync()
        {
            await client.AddProjectUserAsync(generalConfig.ProjectKey, numericAnotherUserId);

            var administrator = await client.AddProjectAdministratorAsync(generalConfig.ProjectKey, numericAnotherUserId);
            Assert.AreEqual(administrator.UserId, projectConfig.AnotherUserId);
            Assert.IsFalse(string.IsNullOrEmpty(administrator.Name));
            Assert.IsFalse(string.IsNullOrEmpty(administrator.MailAddress));

            var administrators = await client.GetProjectAdministratorsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(administrators.Any(x => x.Id == numericAnotherUserId && x.UserId == projectConfig.AnotherUserId));

            var deleteaAministrator = await client.RemoveProjectAdministratorAsync(generalConfig.ProjectKey, numericAnotherUserId);
            Assert.AreEqual(deleteaAministrator.UserId, projectConfig.AnotherUserId);

            administrators = await client.GetProjectAdministratorsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(administrators.Any(x => x.Id == numericAnotherUserId && x.UserId == projectConfig.AnotherUserId));

            await client.RemoveProjectUserAsync(generalConfig.ProjectKey, numericAnotherUserId);
        }

        [TestMethod]
        public async Task CustomFieldTestAsync()
        {
            var issueTypes = (await client.GetIssueTypesAsync(generalConfig.ProjectKey)).Select(x => x.Id).OrderBy(x => x).ToArray();
            var applicableIssueTypes = issueTypes.Take(2).ToArray();
            var applicableIssueTypesUpdated = issueTypes.Skip(2).ToArray();

            var text = await client.AddTextCustomFieldAsync(new AddTextCustomFieldParams(generalConfig.ProjectKey, "TextCustomFieldText")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "TextCustomFieldTextDesc",
                Required = true
            });
            Assert.AreEqual(text.FieldType, CustomFieldType.Text);
            Assert.AreEqual(text.Name, "TextCustomFieldText");
            Assert.AreEqual(text.Description, "TextCustomFieldTextDesc");
            Assert.IsTrue(text.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(text.IsRequired);

            var textUpdated = await client.UpdateTextCustomFieldAsync(new UpdateTextCustomFieldParams(generalConfig.ProjectKey, text.Id)
            {
                Name = "TextCustomFieldTextUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "TextCustomFieldTextDescUpdated",
                Required = false
            });
            Assert.AreEqual(textUpdated.FieldType, CustomFieldType.Text);
            Assert.AreEqual(textUpdated.Name, "TextCustomFieldTextUpdated");
            Assert.AreEqual(textUpdated.Description, "TextCustomFieldTextDescUpdated");
            Assert.IsTrue(textUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(textUpdated.IsRequired);

            var customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is TextCustomFieldSetting && x.Id == textUpdated.Id && x.Name == textUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, textUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == textUpdated.Id));

            var textArea = await client.AddTextAreaCustomFieldAsync(new AddTextAreaCustomFieldParams(generalConfig.ProjectKey, "TextAreaCustomFieldText")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "TextAreaCustomFieldTextDesc",
                Required = true
            });
            Assert.AreEqual(textArea.FieldType, CustomFieldType.TextArea);
            Assert.AreEqual(textArea.Name, "TextAreaCustomFieldText");
            Assert.AreEqual(textArea.Description, "TextAreaCustomFieldTextDesc");
            Assert.IsTrue(textArea.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(textArea.IsRequired);

            var textAreaUpdated = await client.UpdateTextAreaCustomFieldAsync(new UpdateTextAreaCustomFieldParams(generalConfig.ProjectKey, textArea.Id)
            {
                Name = "TextAreaCustomFieldTextUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "TextAreaCustomFieldTextDescUpdated",
                Required = false
            });
            Assert.AreEqual(textAreaUpdated.FieldType, CustomFieldType.TextArea);
            Assert.AreEqual(textAreaUpdated.Name, "TextAreaCustomFieldTextUpdated");
            Assert.AreEqual(textAreaUpdated.Description, "TextAreaCustomFieldTextDescUpdated");
            Assert.IsTrue(textAreaUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(textAreaUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is TextAreaCustomFieldSetting && x.Id == textAreaUpdated.Id && x.Name == textAreaUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, textAreaUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == textAreaUpdated.Id));

            var numeric = await client.AddNumericCustomFieldAsync(new AddNumericCustomFieldParams(generalConfig.ProjectKey, "CustomNumericFieldName")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomNumericFieldDesc",
                InitialValue = -1.3m,
                Min = -100,
                Max = 100,
                Unit = "m",
                Required = true
            });
            Assert.AreEqual(numeric.FieldType, CustomFieldType.Numeric);
            Assert.AreEqual(numeric.Name, "CustomNumericFieldName");
            Assert.AreEqual(numeric.Description, "CustomNumericFieldDesc");
            Assert.AreEqual(numeric.InitialValue, -1.3m);
            Assert.AreEqual(numeric.Min, -100m);
            Assert.AreEqual(numeric.Max, 100m);
            Assert.AreEqual(numeric.Unit, "m");
            Assert.IsTrue(numeric.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(numeric.IsRequired);

            var numericUpdated = await client.UpdateNumericCustomFieldAsync(new UpdateNumericCustomFieldParams(generalConfig.ProjectKey, numeric.Id)
            {
                Name = "CustomNumericFieldNameUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomNumericFieldDescUpdated",
                InitialValue = 1.6m,
                Min = -1000,
                Max = null,
                Unit = "cm",
                Required = false
            });
            Assert.AreEqual(numericUpdated.FieldType, CustomFieldType.Numeric);
            Assert.AreEqual(numericUpdated.Name, "CustomNumericFieldNameUpdated");
            Assert.AreEqual(numericUpdated.Description, "CustomNumericFieldDescUpdated");
            Assert.AreEqual(numericUpdated.InitialValue, 1.6m);
            Assert.AreEqual(numericUpdated.Min, -1000m);
            Assert.AreEqual(numericUpdated.Max, null);
            Assert.AreEqual(numericUpdated.Unit, "cm");
            Assert.IsTrue(numericUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(numericUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is NumericCustomFieldSetting && x.Id == numericUpdated.Id && x.Name == numericUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, numericUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == numericUpdated.Id));

            var date1 = await client.AddDateCustomFieldAsync(new AddDateCustomFieldParams(generalConfig.ProjectKey, "CustomDateFieldName1")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomDateFieldDesc1",
                InitialValueType = DateCustomFieldInitialValueType.FixedDate,
                InitialDate = new DateTime(2017, 7, 1),
                Min = new DateTime(2017, 1, 1),
                Max = new DateTime(2017, 12, 31),
                Required = true
            });
            Assert.AreEqual(date1.FieldType, CustomFieldType.Date);
            Assert.AreEqual(date1.Name, "CustomDateFieldName1");
            Assert.AreEqual(date1.Description, "CustomDateFieldDesc1");
            Assert.AreEqual(date1.InitialDate.ValueType, DateCustomFieldInitialValueType.FixedDate);
            Assert.AreEqual(date1.InitialDate.Date, new DateTime(2017, 7, 1));
            Assert.AreEqual(date1.Min, new DateTime(2017, 1, 1));
            Assert.AreEqual(date1.Max, new DateTime(2017, 12, 31));
            Assert.IsTrue(date1.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(date1.IsRequired);

            var date1Updated = await client.UpdateDateCustomFieldAsync(new UpdateDateCustomFieldParams(generalConfig.ProjectKey, date1.Id)
            {
                Name = "CustomDateFieldName1Updated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomDateFieldDesc1Updated",
                InitialValueType = DateCustomFieldInitialValueType.FixedDate,
                InitialDate = new DateTime(2017, 7, 2),
                Min = new DateTime(2017, 1, 2),
                Max = new DateTime(2017, 12, 30),
                Required = false
            });
            Assert.AreEqual(date1Updated.Id, date1.Id);
            Assert.AreEqual(date1Updated.FieldType, CustomFieldType.Date);
            Assert.AreEqual(date1Updated.Name, "CustomDateFieldName1Updated");
            Assert.AreEqual(date1Updated.Description, "CustomDateFieldDesc1Updated");
            Assert.AreEqual(date1Updated.InitialDate.ValueType, DateCustomFieldInitialValueType.FixedDate);
            Assert.AreEqual(date1Updated.InitialDate.Date, new DateTime(2017, 7, 2));
            Assert.AreEqual(date1Updated.Min, new DateTime(2017, 1, 2));
            Assert.AreEqual(date1Updated.Max, new DateTime(2017, 12, 30));
            Assert.IsTrue(date1Updated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(date1Updated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is DateCustomFieldSetting && x.Id == date1Updated.Id && x.Name == date1Updated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, date1Updated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == date1Updated.Id));

            var date2 = await client.AddDateCustomFieldAsync(new AddDateCustomFieldParams(generalConfig.ProjectKey, "CustomDateFieldName2")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomDateFieldDesc2",
                InitialValueType = DateCustomFieldInitialValueType.TodayPlusShiftDays,
                InitialShift = 3,
                Required = true
            });
            Assert.AreEqual(date2.FieldType, CustomFieldType.Date);
            Assert.AreEqual(date2.Name, "CustomDateFieldName2");
            Assert.AreEqual(date2.Description, "CustomDateFieldDesc2");
            Assert.AreEqual(date2.InitialDate.ValueType, DateCustomFieldInitialValueType.TodayPlusShiftDays);
            Assert.AreEqual(date2.InitialDate.Shift, 3);
            Assert.IsTrue(date2.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(date2.IsRequired);

            var date2Update = await client.UpdateDateCustomFieldAsync(new UpdateDateCustomFieldParams(generalConfig.ProjectKey, date2.Id)
            {
                Name = "CustomDateFieldName2Updated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomDateFieldDesc2Updated",
                InitialValueType = DateCustomFieldInitialValueType.TodayPlusShiftDays,
                InitialShift = 5,
                Required = false
            });
            Assert.AreEqual(date2Update.Id, date2.Id);
            Assert.AreEqual(date2Update.FieldType, CustomFieldType.Date);
            Assert.AreEqual(date2Update.Name, "CustomDateFieldName2Updated");
            Assert.AreEqual(date2Update.Description, "CustomDateFieldDesc2Updated");
            Assert.AreEqual(date2Update.InitialDate.ValueType, DateCustomFieldInitialValueType.TodayPlusShiftDays);
            Assert.AreEqual(date2Update.InitialDate.Shift, 5);
            Assert.IsTrue(date2Update.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(date2Update.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is DateCustomFieldSetting && x.Id == date2Update.Id && x.Name == date2Update.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, date2Update.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == date2Update.Id));

            var singleList = await client.AddSingleListCustomFieldAsync(new AddSingleListCustomFieldParams(generalConfig.ProjectKey, "CustomSingleListFieldName")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomSingleListFieldDesc",
                Items = new[] { "A", "B", "C" },
                AllowAddItem = true,
                Required = true,
            });
            Assert.AreEqual(singleList.FieldType, CustomFieldType.SingleList);
            Assert.AreEqual(singleList.Name, "CustomSingleListFieldName");
            Assert.AreEqual(singleList.Description, "CustomSingleListFieldDesc");
            Assert.IsTrue(singleList.Items.Select(x => x.Name).SequenceEqual(new[] { "A", "B", "C" }));
            Assert.IsTrue(singleList.Items.Any(x => x.Id != 0));
            Assert.IsTrue(singleList.Items.Any(x => x.DisplayOrder != 0));
            Assert.IsTrue(singleList.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(singleList.IsAllowAddItem);
            Assert.IsTrue(singleList.IsRequired);

            var singleListUpdated = await client.UpdateSingleListCustomFieldAsync(new UpdateSingleListCustomFieldParams(generalConfig.ProjectKey, singleList.Id)
            {
                Name = "CustomSingleListFieldNameUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomSingleListFieldDescUpdated",
                Items = new[] { "D", "E", "F" },
                AllowAddItem = false,
                Required = false,
            });
            Assert.AreEqual(singleListUpdated.FieldType, CustomFieldType.SingleList);
            Assert.AreEqual(singleListUpdated.Name, "CustomSingleListFieldNameUpdated");
            Assert.AreEqual(singleListUpdated.Description, "CustomSingleListFieldDescUpdated");
            Assert.IsTrue(singleListUpdated.Items.Select(x => x.Name).SequenceEqual(new[] { "D", "E", "F" }));
            Assert.IsTrue(singleListUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(singleListUpdated.IsAllowAddItem);
            Assert.IsFalse(singleListUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is SingleListCustomFieldSetting && x.Id == singleListUpdated.Id && x.Name == singleListUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, singleListUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == singleListUpdated.Id));

            var multipleList = await client.AddMultipleListCustomFieldAsync(new AddMultipleListCustomFieldParams(generalConfig.ProjectKey, "CustomMultipleListFieldName")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomMultipleListFieldDesc",
                Items = new[] { "A", "B", "C" },
                AllowAddItem = true,
                Required = true,
            });
            Assert.AreEqual(multipleList.FieldType, CustomFieldType.MultipleList);
            Assert.AreEqual(multipleList.Name, "CustomMultipleListFieldName");
            Assert.AreEqual(multipleList.Description, "CustomMultipleListFieldDesc");
            Assert.IsTrue(multipleList.Items.Select(x => x.Name).SequenceEqual(new[] { "A", "B", "C" }));
            Assert.IsTrue(multipleList.Items.Any(x => x.Id != 0));
            Assert.IsTrue(multipleList.Items.Any(x => x.DisplayOrder != 0));
            Assert.IsTrue(multipleList.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(multipleList.IsAllowAddItem);
            Assert.IsTrue(multipleList.IsRequired);

            var multipleListUpdated = await client.UpdateMultipleListCustomFieldAsync(new UpdateMultipleListCustomFieldParams(generalConfig.ProjectKey, multipleList.Id)
            {
                Name = "CustomMultipleListFieldNameUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomMultipleListFieldDescUpdated",
                Items = new[] { "D", "E", "F" },
                AllowAddItem = false,
                Required = false,
            });
            Assert.AreEqual(multipleListUpdated.FieldType, CustomFieldType.MultipleList);
            Assert.AreEqual(multipleListUpdated.Name, "CustomMultipleListFieldNameUpdated");
            Assert.AreEqual(multipleListUpdated.Description, "CustomMultipleListFieldDescUpdated");
            Assert.IsTrue(multipleListUpdated.Items.Select(x => x.Name).SequenceEqual(new[] { "D", "E", "F" }));
            Assert.IsTrue(multipleListUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(multipleListUpdated.IsAllowAddItem);
            Assert.IsFalse(multipleListUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is MultipleListCustomFieldSetting && x.Id == multipleListUpdated.Id && x.Name == multipleListUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, multipleListUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == multipleListUpdated.Id));

            var checkBox = await client.AddCheckBoxCustomFieldAsync(new AddCheckBoxCustomFieldParams(generalConfig.ProjectKey, "CustomCheckBoxFieldName")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomCheckBoxFieldDesc",
                Items = new[] { "A", "B", "C" },
                AllowInput = true,
                AllowAddItem = true,
                Required = true,
            });
            Assert.AreEqual(checkBox.FieldType, CustomFieldType.CheckBox);
            Assert.AreEqual(checkBox.Name, "CustomCheckBoxFieldName");
            Assert.AreEqual(checkBox.Description, "CustomCheckBoxFieldDesc");
            Assert.IsTrue(checkBox.Items.Select(x => x.Name).SequenceEqual(new[] { "A", "B", "C" }));
            Assert.IsTrue(checkBox.Items.Any(x => x.Id != 0));
            Assert.IsTrue(checkBox.Items.Any(x => x.DisplayOrder != 0));
            Assert.IsTrue(checkBox.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(checkBox.IsAllowInput);
            Assert.IsTrue(checkBox.IsAllowAddItem);
            Assert.IsTrue(checkBox.IsRequired);

            var checkBoxUpdated = await client.UpdateCheckBoxCustomFieldAsync(new UpdateCheckBoxCustomFieldParams(generalConfig.ProjectKey, checkBox.Id)
            {
                Name = "CustomCheckBoxFieldNameUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomCheckBoxFieldDescUpdated",
                Items = new[] { "D", "E", "F" },
                AllowInput = false,
                AllowAddItem = false,
                Required = false,
            });
            Assert.AreEqual(checkBoxUpdated.FieldType, CustomFieldType.CheckBox);
            Assert.AreEqual(checkBoxUpdated.Name, "CustomCheckBoxFieldNameUpdated");
            Assert.AreEqual(checkBoxUpdated.Description, "CustomCheckBoxFieldDescUpdated");
            Assert.IsTrue(checkBoxUpdated.Items.Select(x => x.Name).SequenceEqual(new[] { "D", "E", "F" }));
            Assert.IsTrue(checkBoxUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(checkBoxUpdated.IsAllowInput);
            Assert.IsFalse(checkBoxUpdated.IsAllowAddItem);
            Assert.IsFalse(checkBoxUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is CheckBoxCustomFieldSetting && x.Id == checkBoxUpdated.Id && x.Name == checkBoxUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, checkBoxUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == checkBoxUpdated.Id));

            var radio = await client.AddRadioCustomFieldAsync(new AddRadioCustomFieldParams(generalConfig.ProjectKey, "CustomRadioFieldName")
            {
                ApplicableIssueTypes = applicableIssueTypes,
                Description = "CustomRadioFieldDesc",
                Items = new[] { "A", "B", "C" },
                AllowInput = true,
                AllowAddItem = true,
                Required = true,
            });
            Assert.AreEqual(radio.FieldType, CustomFieldType.Radio);
            Assert.AreEqual(radio.Name, "CustomRadioFieldName");
            Assert.AreEqual(radio.Description, "CustomRadioFieldDesc");
            Assert.IsTrue(radio.Items.Select(x => x.Name).SequenceEqual(new[] { "A", "B", "C" }));
            Assert.IsTrue(radio.Items.Any(x => x.Id != 0));
            Assert.IsTrue(radio.Items.Any(x => x.DisplayOrder != 0));
            Assert.IsTrue(radio.ApplicableIssueTypes.SequenceEqual(applicableIssueTypes));
            Assert.IsTrue(radio.IsAllowInput);
            Assert.IsTrue(radio.IsAllowAddItem);
            Assert.IsTrue(radio.IsRequired);

            var radioUpdated = await client.UpdateRadioCustomFieldAsync(new UpdateRadioCustomFieldParams(generalConfig.ProjectKey, radio.Id)
            {
                Name = "CustomRadioFieldNameUpdated",
                ApplicableIssueTypes = applicableIssueTypesUpdated,
                Description = "CustomRadioFieldDescUpdated",
                Items = new[] { "D", "E", "F" },
                AllowInput = false,
                AllowAddItem = false,
                Required = false,
            });
            Assert.AreEqual(radioUpdated.FieldType, CustomFieldType.Radio);
            Assert.AreEqual(radioUpdated.Name, "CustomRadioFieldNameUpdated");
            Assert.AreEqual(radioUpdated.Description, "CustomRadioFieldDescUpdated");
            Assert.IsTrue(radioUpdated.Items.Select(x => x.Name).SequenceEqual(new[] { "D", "E", "F" }));
            Assert.IsTrue(radioUpdated.ApplicableIssueTypes.SequenceEqual(applicableIssueTypesUpdated));
            Assert.IsFalse(radioUpdated.IsAllowInput);
            Assert.IsFalse(radioUpdated.IsAllowAddItem);
            Assert.IsFalse(radioUpdated.IsRequired);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsTrue(customFields.Any(x => x is RadioCustomFieldSetting && x.Id == radioUpdated.Id && x.Name == radioUpdated.Name));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, radioUpdated.Id);

            customFields = await client.GetCustomFieldsAsync(generalConfig.ProjectKey);
            Assert.IsFalse(customFields.Any(x => x.Id == radioUpdated.Id));
        }

        [TestMethod]
        public async Task ListCustomFieldItemTestAsync()
        {
            var checkBox = await client.AddCheckBoxCustomFieldAsync(new AddCheckBoxCustomFieldParams(generalConfig.ProjectKey, "CustomCheckBoxFieldName")
            {
                Items = new[] { "A", "B", "C" },
            });

            var checkBoxAddItem = (CheckBoxCustomFieldSetting)await client.AddListCustomFieldItemAsync(generalConfig.ProjectKey, checkBox.Id, "D");
            Assert.AreEqual(checkBoxAddItem.Items[3].Name, "D");

            var checkBoxUpdateItem = (CheckBoxCustomFieldSetting)await client.UpdateListCustomFieldItemAsync(generalConfig.ProjectKey, checkBox.Id, checkBox.Items[0].Id, "0");
            Assert.AreEqual(checkBoxUpdateItem.Items[0].Name, "0");

            var checkBoxRemoveItem = (CheckBoxCustomFieldSetting)await client.RemoveListCustomFieldItemAsync(generalConfig.ProjectKey, checkBox.Id, checkBoxAddItem.Items[3].Id);
            Assert.AreEqual(checkBoxRemoveItem.Items.Count, 3);
            Assert.IsFalse(checkBoxRemoveItem.Items.Any(x => x.Name == "D"));

            await client.RemoveCustomFieldAsync(generalConfig.ProjectKey, checkBox.Id);
        }
    }
}
