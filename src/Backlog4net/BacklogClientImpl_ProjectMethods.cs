using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Backlog4net.Http;
    using Backlog4net.Internal.File;
    using Backlog4net.Internal.Json;
    using Backlog4net.Internal.Json.CustomFields;
    using System.Net;

    partial class BacklogClientImpl
    {
        public async Task<Category> AddCategoryAsync(AddCategoryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/categories"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateCategoryAsync(response);
            }
        }
        private async Task<T> AddCustomFieldAsync<T>(AddCustomFieldParams @params, CancellationToken? token = default(CancellationToken?)) where T : CustomFieldSetting
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/customFields"), @params, token))
            using (var content = response.Content)
            {
                return (T)await Factory.CreateCustomFieldAsync(response);
            }
        }

        public Task<CheckBoxCustomFieldSetting> AddCheckBoxCustomFieldAsync(AddCheckBoxCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<CheckBoxCustomFieldSetting>(@params, token);

        public Task<DateCustomFieldSetting> AddDateCustomFieldAsync(AddDateCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<DateCustomFieldSetting>(@params, token);

        public async Task<IssueType> AddIssueTypeAsync(AddIssueTypeParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/issueTypes"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueTypeAsync(response);
            }
        }

        public async Task<CustomFieldSetting> AddListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, string name, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("name", name)};
            using (var response = await Post(BuildEndpoint($"projects/{projectIdOrKey}/customFields/{customFieldId}/items"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateCustomFieldAsync(response);
            }
        }

        public async Task<Milestone> AddMilestoneAsync(AddMilestoneParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/versions"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateMilestoneAsync(response);
            }
        }

        public Task<MultipleListCustomFieldSetting> AddMultipleListCustomFieldAsync(AddMultipleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?)) 
            => AddCustomFieldAsync<MultipleListCustomFieldSetting>(@params, token);


        public Task<NumericCustomFieldSetting> AddNumericCustomFieldAsync(AddNumericCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<NumericCustomFieldSetting>(@params, token);

        public async Task<User> AddProjectAdministratorAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("userId", userId.ToString()) };
            using (var response = await Post(BuildEndpoint($"projects/{projectIdOrKey}/administrators"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<User> AddProjectUserAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("userId", userId.ToString()) };
            using (var response = await Post(BuildEndpoint($"projects/{projectIdOrKey}/users"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public Task<RadioCustomFieldSetting> AddRadioCustomFieldAsync(AddRadioCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<RadioCustomFieldSetting>(@params, token);

        public Task<SingleListCustomFieldSetting> AddSingleListCustomFieldAsync(AddSingleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<SingleListCustomFieldSetting>(@params, token);

        public Task<TextAreaCustomFieldSetting> AddTextAreaCustomFieldAsync(AddTextAreaCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<TextAreaCustomFieldSetting>(@params, token);

        public Task<TextCustomFieldSetting> AddTextCustomFieldAsync(AddTextCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => AddCustomFieldAsync<TextCustomFieldSetting>(@params, token);

        public async Task<Version> AddVersionAsync(AddVersionParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/versions"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateVersionAsync(response);
            }
        }

        public async Task<Project> CreateProjectAsync(CreateProjectParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateProjectAsync(response);
            }
        }

        public async Task<Project> DeleteProjectAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateProjectAsync(response);
            }
        }

        public async Task<SharedFileData> DownloadSharedFileAsync(IdOrKey projectIdOrKey, long sharedFileId, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.SharedFileEndpoint(projectIdOrKey, sharedFileId));
            return await SharedFileDataImpl.CreateaAsync(response);
        }

        public async Task<ResponseList<Category>> GetCategoriesAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/categories"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCategoryListAsync(response);
            }
        }

        public async Task<ResponseList<CustomFieldSetting>> GetCustomFieldsAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/customFields"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCustomFieldListAsync(response);
            }
        }

        public async Task<ResponseList<IssueType>> GetIssueTypesAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/issueTypes"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueTypeListAsync(response);
            }
        }

        public async Task<ResponseList<Milestone>> GetMilestonesAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/versions"), token: token))
            using (var content = response.Content)
            {
                return new ResponseListImpl<Milestone>((await Factory.CreateMilestoneListAsync(response)).Where(x => !x.Archived));
            }
        }

        public async Task<ResponseList<Activity>> GetProjectActivitiesAsync(IdOrKey projectIdOrKey, ActivityQueryParams query = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/activities"), query, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateActivityListAsync(response);
            }
        }

        public async Task<ResponseList<User>> GetProjectAdministratorsAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/administrators"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserListAsync(response);
            }
        }

        public async Task<Project> GetProjectAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateProjectAsync(response);
            }
        }

        public async Task<DiskUsageDetail> GetProjectDiskUsageAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/diskUsage"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateDiskUsageDetailAsync(response);
            }
        }

        public async Task<Icon> GetProjectIconAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.ProjectIconEndpoint(projectIdOrKey));
            return await IconImpl.CreateaAsync(response);
        }

        public async Task<ResponseList<Project>> GetProjectsAsync(CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("projects"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateProjectListAsync(response));
            }
        }

        public async Task<ResponseList<User>> GetProjectUsersAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/users"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserListAsync(response);
            }
        }

        public async Task<ResponseList<SharedFile>> GetSharedFilesAsync(IdOrKey projectIdOrKey, string path, QueryParams queryParams = null, CancellationToken? token = default(CancellationToken?))
        {
            var encodedPath = WebUtility.UrlEncode(path);
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/files/metadata/{encodedPath}"), queryParams, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateSharedFileListAsync(response);
            }
        }

        public async Task<ResponseList<Version>> GetVersionsAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/versions"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateVersionListAsync(response);
            }
        }

        public async Task<Category> RemoveCategoryAsync(IdOrKey projectIdOrKey, long categoryId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/categories/{categoryId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCategoryAsync(response);
            }
        }

        public async Task<CustomFieldSetting> RemoveCustomFieldAsync(IdOrKey projectIdOrKey, long customFieldId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/customFields/{customFieldId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCustomFieldAsync(response);
            }
        }

        public async Task<IssueType> RemoveIssueTypeAsync(IdOrKey projectIdOrKey, long issueTypeId, long substituteIssueTypeId, CancellationToken? token = default(CancellationToken?))
        {
            var param = new NameValuePair("substituteIssueTypeId", substituteIssueTypeId.ToString());
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/issueTypes/{issueTypeId}"), param, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueTypeAsync(response);
            }
        }

        public async Task<CustomFieldSetting> RemoveListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, long itemId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/customFields/{customFieldId}/items/{itemId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCustomFieldAsync(response);
            }
        }

        public async Task<Milestone> RemoveMilestoneAsync(IdOrKey projectIdOrKey, long MilestoneId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/versions/{MilestoneId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateMilestoneAsync(response);
            }
        }

        public async Task<User> RemoveProjectAdministratorAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = default(CancellationToken?))
        {
            var param = new NameValuePair("userId", userId.ToString());
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/administrators"), param, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<User> RemoveProjectUserAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = default(CancellationToken?))
        {
            var param = new NameValuePair("userId", userId.ToString());
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/users"), param, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<Version> RemoveVersionAsync(IdOrKey projectIdOrKey, long versionId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/versions/{versionId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateVersionAsync(response);
            }
        }

        public async Task<Category> UpdateCategoryAsync(UpdateCategoryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/categories/{@params.CategoryId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCategoryAsync(response);
            }
        }

        private async Task<T> UpdateCustomFieldAsync<T>(UpdateCustomFieldParams @params, CancellationToken? token = default(CancellationToken?)) where T : CustomFieldSetting
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/customFields/{@params.CustomFiledId}"), @params, token: token))
            using (var content = response.Content)
            {
                return (T)await Factory.CreateCustomFieldAsync(response);
            }
        }

        public Task<CheckBoxCustomFieldSetting> UpdateCheckBoxCustomFieldAsync(UpdateCheckBoxCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<CheckBoxCustomFieldSetting>(@params, token);

        public Task<DateCustomFieldSetting> UpdateDateCustomFieldAsync(UpdateDateCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<DateCustomFieldSetting>(@params, token);

        public async Task<IssueType> UpdateIssueTypeAsync(UpdateIssueTypeParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/issueTypes/{@params.IssueTypeId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueTypeAsync(response);
            }
        }

        public async Task<CustomFieldSetting> UpdateListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, long itemId, string name, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("name", name) };
            using (var response = await Patch(BuildEndpoint($"projects/{projectIdOrKey}/customFields/{customFieldId}/items/{itemId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateCustomFieldAsync(response);
            }
        }

        public async Task<Milestone> UpdateMilestoneAsync(UpdateMilestoneParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/versions/{@params.VersionId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateMilestoneAsync(response);
            }
        }

        public Task<MultipleListCustomFieldSetting> UpdateMultipleListCustomFieldAsync(UpdateMultipleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<MultipleListCustomFieldSetting>(@params, token);

        public Task<NumericCustomFieldSetting> UpdateNumericCustomFieldAsync(UpdateNumericCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<NumericCustomFieldSetting>(@params, token);

        public async Task<Project> UpdateProjectAsync(UpdateProjectParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateProjectAsync(response);
            }
        }

        public Task<RadioCustomFieldSetting> UpdateRadioCustomFieldAsync(UpdateRadioCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<RadioCustomFieldSetting>(@params, token);

        public Task<SingleListCustomFieldSetting> UpdateSingleListCustomFieldAsync(UpdateSingleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<SingleListCustomFieldSetting>(@params, token);

        public Task<TextAreaCustomFieldSetting> UpdateTextAreaCustomFieldAsync(UpdateTextAreaCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<TextAreaCustomFieldSetting>(@params, token);

        public Task<TextCustomFieldSetting> UpdateTextCustomFieldAsync(UpdateTextCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
            => UpdateCustomFieldAsync<TextCustomFieldSetting>(@params, token);

        public async Task<Version> UpdateVersionAsync(UpdateVersionParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/versions/{@params.VersionId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateVersionAsync(response);
            }
        }
    }
}
