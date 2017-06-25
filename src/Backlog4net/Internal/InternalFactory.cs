using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backlog4net.Internal
{
    using Auth;

    interface InternalFactory
    {
        //AccessToken CreateAccessToken(HttpResponseMessage res);

        //Space CreateSpace(HttpResponseMessage res);

        //SpaceNotification CreateSpaceNotification(HttpResponseMessage res);

        //DiskUsage CreateDiskUsage(HttpResponseMessage res);

        //DiskUsageDetail CreateDiskUsageDetail(HttpResponseMessage res);

        //ResponseList<Project> CreateProjectList(HttpResponseMessage res);

        //Project CreateProject(HttpResponseMessage res);

        //ResponseList<Activity> CreateActivityList(HttpResponseMessage res);

        //Activity CreateActivity(HttpResponseMessage res);

        //ResponseList<Issue> CreateIssueList(HttpResponseMessage res);

        //Issue CreateIssue(HttpResponseMessage res);

        //Issue importIssue(HttpResponseMessage res);

        //ResponseList<IssueComment> CreateIssueCommentList(HttpResponseMessage res);

        //IssueComment CreateIssueComment(HttpResponseMessage res);

        Task<ResponseList<User>> CreateUserList(HttpResponseMessage res);

        //User CreateUser(HttpResponseMessage res);

        //ResponseList<IssueType> CreateIssueTypeList(HttpResponseMessage res);

        //IssueType CreateIssueType(HttpResponseMessage res);

        //ResponseList<Category> CreateCategoryList(HttpResponseMessage res);

        //Category CreateCategory(HttpResponseMessage res);

        //ResponseList<CustomFieldSetting> CreateCustomFieldList(HttpResponseMessage res);

        //CustomFieldSetting CreateCustomField(HttpResponseMessage res);

        //ResponseList<Priority> CreatePriorityList(HttpResponseMessage res);

        //ResponseList<Resolution> CreateResolutionList(HttpResponseMessage res);

        //ResponseList<Status> CreateStatusList(HttpResponseMessage res);

        //ResponseList<Star> CreateStarList(HttpResponseMessage res);

        //Star CreateStar(HttpResponseMessage res);

        //Count CreateCount(HttpResponseMessage res);

        //ResponseList<Version> CreateVersionList(HttpResponseMessage res);

        //Version CreateVersion(HttpResponseMessage res);

        //ResponseList<Milestone> CreateMilestoneList(HttpResponseMessage res);

        //Milestone CreateMilestone(HttpResponseMessage res);

        //Wiki CreateWiki(HttpResponseMessage res);

        //Wiki importWiki(HttpResponseMessage res);

        //ResponseList<Wiki> CreateWikiList(HttpResponseMessage res);

        //ResponseList<WikiTag> CreateWikiTagList(HttpResponseMessage res);

        //WikiHistory CreateWikiHistory(HttpResponseMessage res);

        //WikiTag CreateWikiTag(HttpResponseMessage res);

        //ResponseList<WikiHistory> CreateWikiHistoryList(HttpResponseMessage res);

        //ResponseList<Notification> CreateNotificationList(HttpResponseMessage res);

        //Repository CreateRepository(HttpResponseMessage res);

        //ResponseList<Repository> CreateRepositoryList(HttpResponseMessage res);

        //PullRequest CreatePullRequest(HttpResponseMessage res);

        //ResponseList<PullRequest> CreatePullRequestList(HttpResponseMessage res);

        //PullRequestComment CreatePullRequestComment(HttpResponseMessage res);

        //ResponseList<PullRequestComment> CreatePullRequestCommentList(HttpResponseMessage res);

        //ResponseList<ViewedIssue> CreateViewedIssueList(HttpResponseMessage res);

        //ResponseList<ViewedProject> CreateViewedProjectList(HttpResponseMessage res);

        //ResponseList<ViewedWiki> CreateViewedWikiList(HttpResponseMessage res);

        //ResponseList<SharedFile> CreateSharedFileList(HttpResponseMessage res);

        //SharedFile CreateSharedFile(HttpResponseMessage res);

        //ResponseList<Attachment> CreateAttachmentList(HttpResponseMessage res);

        //Attachment CreateAttachment(HttpResponseMessage res);

        //Group CreateGroup(HttpResponseMessage res);

        //ResponseList<Group> CreateGroupList(HttpResponseMessage res);

        //ResponseList<Webhook> CreateWebhookList(HttpResponseMessage res);

        //Webhook CreateWebhook(HttpResponseMessage res);

        //Watch CreateWatch(HttpResponseMessage res);

        //ResponseList<Watch> CreateWatchList(HttpResponseMessage res);
    }
}
