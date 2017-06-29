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
        Task<AccessToken> CreateAccessTokenAsync(HttpResponseMessage res);

        Task<Space> CreateSpaceAsync(HttpResponseMessage res);

        Task<SpaceNotification> CreateSpaceNotificationAsync(HttpResponseMessage res);

        Task<DiskUsage> CreateDiskUsageAsync(HttpResponseMessage res);

        Task<DiskUsageDetail> CreateDiskUsageDetailAsync(HttpResponseMessage res);

        Task<ResponseList<Project>> CreateProjectListAsync(HttpResponseMessage res);

        Task<Project> CreateProjectAsync(HttpResponseMessage res);

        Task<ResponseList<Activity>> CreateActivityListAsync(HttpResponseMessage res);

        Task<Activity> CreateActivityAsync(HttpResponseMessage res);

        Task<ResponseList<Issue>> CreateIssueListAsync(HttpResponseMessage res);

        Task<Issue> CreateIssueAsync(HttpResponseMessage res);

        Task<Issue> ImportIssueAsync(HttpResponseMessage res);

        Task<ResponseList<IssueComment>> CreateIssueCommentListAsync(HttpResponseMessage res);

        Task<IssueComment> CreateIssueCommentAsync(HttpResponseMessage res);

        Task<ResponseList<User>> CreateUserListAsync(HttpResponseMessage res);

        Task<User> CreateUserAsync(HttpResponseMessage res);

        Task<ResponseList<IssueType>> CreateIssueTypeListAsync(HttpResponseMessage res);

        Task<IssueType> CreateIssueTypeAsync(HttpResponseMessage res);

        Task<ResponseList<Category>> CreateCategoryListAsync(HttpResponseMessage res);

        Task<Category> CreateCategoryAsync(HttpResponseMessage res);

        Task<ResponseList<CustomFieldSetting>> CreateCustomFieldListAsync(HttpResponseMessage res);

        Task<CustomFieldSetting> CreateCustomFieldAsync(HttpResponseMessage res);

        Task<ResponseList<Priority>> CreatePriorityListAsync(HttpResponseMessage res);

        Task<ResponseList<Resolution>> CreateResolutionListAsync(HttpResponseMessage res);

        Task<ResponseList<Status>> CreateStatusListAsync(HttpResponseMessage res);

        Task<ResponseList<Star>> CreateStarListAsync(HttpResponseMessage res);

        Task<Star> CreateStarAsync(HttpResponseMessage res);

        Task<Count> CreateCountAsync(HttpResponseMessage res);

        Task<ResponseList<Version>> CreateVersionListAsync(HttpResponseMessage res);

        Task<Version> CreateVersionAsync(HttpResponseMessage res);

        Task<ResponseList<Milestone>> CreateMilestoneListAsync(HttpResponseMessage res);

        Task<Milestone> CreateMilestoneAsync(HttpResponseMessage res);

        Task<Wiki> CreateWikiAsync(HttpResponseMessage res);

        Task<Wiki> ImportWikiAsync(HttpResponseMessage res);

        Task<ResponseList<Wiki>> CreateWikiListAsync(HttpResponseMessage res);

        Task<ResponseList<WikiTag>> CreateWikiTagListAsync(HttpResponseMessage res);

        Task<WikiHistory> CreateWikiHistoryAsync(HttpResponseMessage res);

        Task<WikiTag> CreateWikiTagAsync(HttpResponseMessage res);

        Task<ResponseList<WikiHistory>> CreateWikiHistoryListAsync(HttpResponseMessage res);

        Task<ResponseList<Notification>> CreateNotificationListAsync(HttpResponseMessage res);

        Task<Repository> CreateRepositoryAsync(HttpResponseMessage res);

        Task<ResponseList<Repository>> CreateRepositoryListAsync(HttpResponseMessage res);

        Task<PullRequest> CreatePullRequestAsync(HttpResponseMessage res);

        Task<ResponseList<PullRequest>> CreatePullRequestListAsync(HttpResponseMessage res);

        Task<PullRequestComment> CreatePullRequestCommentAsync(HttpResponseMessage res);

        Task<ResponseList<PullRequestComment>> CreatePullRequestCommentListAsync(HttpResponseMessage res);

        Task<ResponseList<ViewedIssue>> CreateViewedIssueListAsync(HttpResponseMessage res);

        Task<ResponseList<ViewedProject>> CreateViewedProjectListAsync(HttpResponseMessage res);

        Task<ResponseList<ViewedWiki>> CreateViewedWikiListAsync(HttpResponseMessage res);

        Task<ResponseList<SharedFile>> CreateSharedFileListAsync(HttpResponseMessage res);

        Task<SharedFile> CreateSharedFileAsync(HttpResponseMessage res);

        Task<ResponseList<Attachment>> CreateAttachmentListAsync(HttpResponseMessage res);

        Task<Attachment> CreateAttachmentAsync(HttpResponseMessage res);

        Task<Group> CreateGroupAsync(HttpResponseMessage res);

        Task<ResponseList<Group>> CreateGroupListAsync(HttpResponseMessage res);

        Task<ResponseList<Webhook>> CreateWebhookListAsync(HttpResponseMessage res);

        Task<Webhook> CreateWebhookAsync(HttpResponseMessage res);

        Task<Watch> CreateWatchAsync(HttpResponseMessage res);

        Task<ResponseList<Watch>> CreateWatchListAsync(HttpResponseMessage res);
    }
}
