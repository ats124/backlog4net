using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Backlog4net.Auth;

namespace Backlog4net.Internal.Json
{
    using Auth;
    using Activities;
    using CustomFields;

    class InternalFactoryJsonImpl : InternalFactory
    {
        private ResponseList<T1> CreateObjectList<T1, TConverter>(string content) where TConverter : JsonConverter, new()
            => new ResponseListImpl<T1>(JsonConvert.DeserializeObject<T1[]>(content, new TConverter()).Cast<T1>());

        private T1 CreateObject<T1, TConverter>(string content) where TConverter : JsonConverter, new()
            => JsonConvert.DeserializeObject<T1>(content, new TConverter());

        public AccessToken CreateAccessToken(string resStr)
            => CreateObject<AccessToken, AccessTokenJsonImpl.JsonConverter>(resStr);

        public async Task<AccessToken> CreateAccessTokenAsync(HttpResponseMessage res)
            => CreateAccessToken(await res.Content.ReadAsStringAsync());

        public Space CreateSpace(string resStr)
            => CreateObject<Space, SpaceJsonImp.JsonConverter>(resStr);

        public async Task<Space> CreateSpaceAsync(HttpResponseMessage res)
            => CreateSpace(await res.Content.ReadAsStringAsync());

        public SpaceNotification CreateSpaceNotification(string resStr)
            => CreateObject<SpaceNotification, SpaceNotificationJsonImpl.JsonConverter>(resStr);

        public async Task<SpaceNotification> CreateSpaceNotificationAsync(HttpResponseMessage res)
            => CreateSpaceNotification(await res.Content.ReadAsStringAsync());

        public DiskUsage CreateDiskUsage(string resStr)
            => CreateObject<DiskUsage, DiskUsageJsonImpl.JsonConverter>(resStr);

        public async Task<DiskUsage> CreateDiskUsageAsync(HttpResponseMessage res)
            => CreateDiskUsage(await res.Content.ReadAsStringAsync());

        public DiskUsageDetail CreateDiskUsageDetail(string resStr)
            => CreateObject<DiskUsageDetail, DiskUsageDetailJsonImpl.JsonConverter>(resStr);

        public async Task<DiskUsageDetail> CreateDiskUsageDetailAsync(HttpResponseMessage res)
            => CreateDiskUsageDetail(await res.Content.ReadAsStringAsync());

        public ResponseList<Project> CreateProjectList(string resStr)
            => CreateObjectList<Project, ProjectJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Project>> CreateProjectListAsync(HttpResponseMessage res)
            => CreateProjectList(await res.Content.ReadAsStringAsync());

        public Project CreateProject(string resStr)
            => CreateObject<Project, ProjectJsonImpl.JsonConverter>(resStr);

        public async Task<Project> CreateProjectAsync(HttpResponseMessage res)
            => CreateProject(await res.Content.ReadAsStringAsync());

        public ResponseList<Activity> CreateActivityList(string resStr)
            => CreateObjectList<Activity, ActivityJsonImplBase.JsonConverter>(resStr);

        public async Task<ResponseList<Activity>> CreateActivityListAsync(HttpResponseMessage res)
            => CreateActivityList(await res.Content.ReadAsStringAsync());

        public Activity CreateActivity(string resStr)
            => CreateObject<Activity, ActivityJsonImplBase.JsonConverter>(resStr);

        public async Task<Activity> CreateActivityAsync(HttpResponseMessage res)
            => CreateActivity(await res.Content.ReadAsStringAsync());

        public ResponseList<Issue> CreateIssueList(string resStr)
            => CreateObjectList<Issue, IssueJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Issue>> CreateIssueListAsync(HttpResponseMessage res)
            => CreateIssueList(await res.Content.ReadAsStringAsync());

        public Issue CreateIssue(string resStr)
            => CreateObject<Issue, IssueJsonImpl.JsonConverter>(resStr);

        public async Task<Issue> CreateIssueAsync(HttpResponseMessage res)
            => CreateIssue(await res.Content.ReadAsStringAsync());

        public Issue ImportIssue(string resStr)
            => CreateObject<Issue, IssueJsonImpl.JsonConverter>(resStr);

        public async Task<Issue> ImportIssueAsync(HttpResponseMessage res)
            => ImportIssue(await res.Content.ReadAsStringAsync());

        public ResponseList<IssueComment> CreateIssueCommentList(string resStr)
            => CreateObjectList<IssueComment, IssueCommentJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<IssueComment>> CreateIssueCommentListAsync(HttpResponseMessage res)
            => CreateIssueCommentList(await res.Content.ReadAsStringAsync());

        public IssueComment CreateIssueComment(string resStr)
            => CreateObject<IssueComment, IssueCommentJsonImpl.JsonConverter>(resStr);

        public async Task<IssueComment> CreateIssueCommentAsync(HttpResponseMessage res)
            => CreateIssueComment(await res.Content.ReadAsStringAsync());

        public ResponseList<User> CreateUserList(string resStr)
            => CreateObjectList<User, UserJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<User>> CreateUserListAsync(HttpResponseMessage res) 
            => CreateUserList(await res.Content.ReadAsStringAsync());

        public User CreateUser(string resStr)
            => CreateObject<User, UserJsonImpl.JsonConverter>(resStr);

        public async Task<User> CreateUserAsync(HttpResponseMessage res)
            => CreateUser(await res.Content.ReadAsStringAsync());

        public ResponseList<IssueType> CreateIssueTypeList(string resStr)
            => CreateObjectList<IssueType, IssueTypeJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<IssueType>> CreateIssueTypeListAsync(HttpResponseMessage res)
            => CreateIssueTypeList(await res.Content.ReadAsStringAsync());

        public IssueType CreateIssueType(string resStr)
            => CreateObject<IssueType, IssueTypeJsonImpl.JsonConverter>(resStr);

        public async Task<IssueType> CreateIssueTypeAsync(HttpResponseMessage res)
            => CreateIssueType(await res.Content.ReadAsStringAsync());

        public ResponseList<Category> CreateCategoryList(string resStr)
            => CreateObjectList<Category, CategoryJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Category>> CreateCategoryListAsync(HttpResponseMessage res)
            => CreateCategoryList(await res.Content.ReadAsStringAsync());

        public Category CreateCategory(string resStr)
            => CreateObject<Category, CategoryJsonImpl.JsonConverter>(resStr);

        public async Task<Category> CreateCategoryAsync(HttpResponseMessage res)
            => CreateCategory(await res.Content.ReadAsStringAsync());

        public ResponseList<CustomFieldSetting> CreateCustomFieldList(string resStr)
            => CreateObjectList<CustomFieldSetting, CustomFieldSettingJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<CustomFieldSetting>> CreateCustomFieldListAsync(HttpResponseMessage res)
            => CreateCustomFieldList(await res.Content.ReadAsStringAsync());

        public CustomFieldSetting CreateCustomField(string resStr)
            => CreateObject<CustomFieldSetting, CustomFieldSettingJsonImpl.JsonConverter>(resStr);

        public async Task<CustomFieldSetting> CreateCustomFieldAsync(HttpResponseMessage res)
            => CreateCustomField(await res.Content.ReadAsStringAsync());

        public ResponseList<Priority> CreatePriorityList(string resStr)
            => CreateObjectList<Priority, PriorityJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Priority>> CreatePriorityListAsync(HttpResponseMessage res)
            => CreatePriorityList(await res.Content.ReadAsStringAsync());

        public ResponseList<Resolution> CreateResolutionList(string resStr)
            => CreateObjectList<Resolution, ResolutionJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Resolution>> CreateResolutionListAsync(HttpResponseMessage res)
            => CreateResolutionList(await res.Content.ReadAsStringAsync());

        public ResponseList<Status> CreateStatusList(string resStr)
            => CreateObjectList<Status, StatusJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Status>> CreateStatusListAsync(HttpResponseMessage res)
            => CreateStatusList(await res.Content.ReadAsStringAsync());

        public ResponseList<Star> CreateStarList(string resStr)
            => CreateObjectList<Star, StarJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Star>> CreateStarListAsync(HttpResponseMessage res)
            => CreateStarList(await res.Content.ReadAsStringAsync());

        public Star CreateStar(string resStr)
            => CreateObject<Star, StarJsonImpl.JsonConverter>(resStr);

        public async Task<Star> CreateStarAsync(HttpResponseMessage res)
            => CreateStar(await res.Content.ReadAsStringAsync());

        public Count CreateCount(string resStr)
            => CreateObject<Count, CountJsonImpl.JsonConverter>(resStr);

        public async Task<Count> CreateCountAsync(HttpResponseMessage res)
            => CreateCount(await res.Content.ReadAsStringAsync());

        public ResponseList<Version> CreateVersionList(string resStr)
            => CreateObjectList<Version, VersionJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Version>> CreateVersionListAsync(HttpResponseMessage res)
            => CreateVersionList(await res.Content.ReadAsStringAsync());

        public Version CreateVersion(string resStr)
            => CreateObject<Version, VersionJsonImpl.JsonConverter>(resStr);

        public async Task<Version> CreateVersionAsync(HttpResponseMessage res)
            => CreateVersion(await res.Content.ReadAsStringAsync());

        public ResponseList<Milestone> CreateMilestoneList(string resStr)
            => CreateObjectList<Milestone, MilestoneJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Milestone>> CreateMilestoneListAsync(HttpResponseMessage res)
            => CreateMilestoneList(await res.Content.ReadAsStringAsync());

        public Milestone CreateMilestone(string resStr)
            => CreateObject<Milestone, MilestoneJsonImpl.JsonConverter>(resStr);

        public async Task<Milestone> CreateMilestoneAsync(HttpResponseMessage res)
            => CreateMilestone(await res.Content.ReadAsStringAsync());

        public Wiki CreateWiki(string resStr)
            => CreateObject<Wiki, WikiJsonImpl.JsonConverter>(resStr);

        public async Task<Wiki> CreateWikiAsync(HttpResponseMessage res)
            => CreateWiki(await res.Content.ReadAsStringAsync());

        public Wiki ImportWiki(string resStr)
            => CreateObject<Wiki, WikiJsonImpl.JsonConverter>(resStr);

        public async Task<Wiki> ImportWikiAsync(HttpResponseMessage res)
            => ImportWiki(await res.Content.ReadAsStringAsync());

        public ResponseList<Wiki> CreateWikiList(string resStr)
            => CreateObjectList<Wiki, WikiJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Wiki>> CreateWikiListAsync(HttpResponseMessage res)
            => CreateWikiList(await res.Content.ReadAsStringAsync());

        public ResponseList<WikiTag> CreateWikiTagList(string resStr)
            => CreateObjectList<WikiTag, WikiTagJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<WikiTag>> CreateWikiTagListAsync(HttpResponseMessage res)
            => CreateWikiTagList(await res.Content.ReadAsStringAsync());

        public WikiHistory CreateWikiHistory(string resStr)
            => CreateObject<WikiHistory, WikiHistoryJsonImpl.JsonConverter>(resStr);

        public async Task<WikiHistory> CreateWikiHistoryAsync(HttpResponseMessage res)
            => CreateWikiHistory(await res.Content.ReadAsStringAsync());

        public ResponseList<WikiHistory> CreateWikiHistoryList(string resStr)
            => CreateObjectList<WikiHistory, WikiHistoryJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<WikiHistory>> CreateWikiHistoryListAsync(HttpResponseMessage res)
            => CreateWikiHistoryList(await res.Content.ReadAsStringAsync());

        public WikiTag CreateWikiTag(string resStr)
            => CreateObject<WikiTag, WikiTagJsonImpl.JsonConverter>(resStr);

        public async Task<WikiTag> CreateWikiTagAsync(HttpResponseMessage res)
            => CreateWikiTag(await res.Content.ReadAsStringAsync());

        public ResponseList<Notification> CreateNotificationList(string resStr)
            => CreateObjectList<Notification, NotificationJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Notification>> CreateNotificationListAsync(HttpResponseMessage res)
            => CreateNotificationList(await res.Content.ReadAsStringAsync());

        public Repository CreateRepository(string resStr)
            => CreateObject<Repository, RepositoryJsonImpl.JsonConverter>(resStr);

        public async Task<Repository> CreateRepositoryAsync(HttpResponseMessage res)
            => CreateRepository(await res.Content.ReadAsStringAsync());

        public ResponseList<Repository> CreateRepositoryList(string resStr)
            => CreateObjectList<Repository, RepositoryJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Repository>> CreateRepositoryListAsync(HttpResponseMessage res)
            => CreateRepositoryList(await res.Content.ReadAsStringAsync());

        public PullRequest CreatePullRequest(string resStr)
            => CreateObject<PullRequest, PullRequestJsonImpl.JsonConverter>(resStr);

        public async Task<PullRequest> CreatePullRequestAsync(HttpResponseMessage res)
            => CreatePullRequest(await res.Content.ReadAsStringAsync());

        public ResponseList<PullRequest> CreatePullRequestList(string resStr)
            => CreateObjectList<PullRequest, PullRequestJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<PullRequest>> CreatePullRequestListAsync(HttpResponseMessage res)
            => CreatePullRequestList(await res.Content.ReadAsStringAsync());

        public ResponseList<PullRequestComment> CreatePullRequestCommentList(string resStr)
            => CreateObjectList<PullRequestComment, PullRequestCommentJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<PullRequestComment>> CreatePullRequestCommentListAsync(HttpResponseMessage res)
            => CreatePullRequestCommentList(await res.Content.ReadAsStringAsync());

        public PullRequestComment CreatePullRequestComment(string resStr)
            => CreateObject<PullRequestComment, PullRequestCommentJsonImpl.JsonConverter>(resStr);

        public async Task<PullRequestComment> CreatePullRequestCommentAsync(HttpResponseMessage res)
            => CreatePullRequestComment(await res.Content.ReadAsStringAsync());

        public ResponseList<ViewedIssue> CreateViewedIssueList(string resStr)
            => CreateObjectList<ViewedIssue, ViewedIssueJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<ViewedIssue>> CreateViewedIssueListAsync(HttpResponseMessage res)
            => CreateViewedIssueList(await res.Content.ReadAsStringAsync());

        public ResponseList<ViewedProject> CreateViewedProjectList(string resStr)
            => CreateObjectList<ViewedProject, ViewedProjectJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<ViewedProject>> CreateViewedProjectListAsync(HttpResponseMessage res)
            => CreateViewedProjectList(await res.Content.ReadAsStringAsync());

        public ResponseList<ViewedWiki> CreateViewedWikiList(string resStr)
            => CreateObjectList<ViewedWiki, ViewedWikiJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<ViewedWiki>> CreateViewedWikiListAsync(HttpResponseMessage res)
            => CreateViewedWikiList(await res.Content.ReadAsStringAsync());

        public ResponseList<SharedFile> CreateSharedFileList(string resStr)
            => CreateObjectList<SharedFile, SharedFileJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<SharedFile>> CreateSharedFileListAsync(HttpResponseMessage res)
            => CreateSharedFileList(await res.Content.ReadAsStringAsync());

        public SharedFile CreateSharedFile(string resStr)
            => CreateObject<SharedFile, SharedFileJsonImpl.JsonConverter>(resStr);

        public async Task<SharedFile> CreateSharedFileAsync(HttpResponseMessage res)
            => CreateSharedFile(await res.Content.ReadAsStringAsync());

        public ResponseList<Attachment> CreateAttachmentList(string resStr)
            => CreateObjectList<Attachment, AttachmentJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Attachment>> CreateAttachmentListAsync(HttpResponseMessage res)
            => CreateAttachmentList(await res.Content.ReadAsStringAsync());

        public Attachment CreateAttachment(string resStr)
            => CreateObject<Attachment, AttachmentJsonImpl.JsonConverter>(resStr);

        public async Task<Attachment> CreateAttachmentAsync(HttpResponseMessage res)
            => CreateAttachment(await res.Content.ReadAsStringAsync());

        public Group CreateGroup(string resStr)
            => CreateObject<Group, GroupJsonImpl.JsonConverter>(resStr);

        public async Task<Group> CreateGroupAsync(HttpResponseMessage res)
            => CreateGroup(await res.Content.ReadAsStringAsync());

        public ResponseList<Group> CreateGroupList(string resStr)
            => CreateObjectList<Group, GroupJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Group>> CreateGroupListAsync(HttpResponseMessage res)
            => CreateGroupList(await res.Content.ReadAsStringAsync());

        public ResponseList<Webhook> CreateWebhookList(string resStr)
            => CreateObjectList<Webhook, WebhookJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Webhook>> CreateWebhookListAsync(HttpResponseMessage res)
            => CreateWebhookList(await res.Content.ReadAsStringAsync());

        public Webhook CreateWebhook(string resStr)
            => CreateObject<Webhook, WebhookJsonImpl.JsonConverter>(resStr);

        public async Task<Webhook> CreateWebhookAsync(HttpResponseMessage res)
            => CreateWebhook(await res.Content.ReadAsStringAsync());

        public Watch CreateWatch(string resStr)
            => CreateObject<Watch, WatchJsonImpl.JsonConverter>(resStr);

        public async Task<Watch> CreateWatchAsync(HttpResponseMessage res)
            => CreateWatch(await res.Content.ReadAsStringAsync());

        public ResponseList<Watch> CreateWatchList(string resStr)
            => CreateObjectList<Watch, WatchJsonImpl.JsonConverter>(resStr);

        public async Task<ResponseList<Watch>> CreateWatchListAsync(HttpResponseMessage res)
            => CreateWatchList(await res.Content.ReadAsStringAsync());
    }
}
