using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Backlog4net.Internal.Json.CustomFields;

    partial class BacklogClientImpl
    {
        public Task<Category> AddCategoryAsync(AddCategoryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CheckBoxCustomFieldSetting> AddCheckBoxCustomFieldAsync(AddCheckBoxCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<DateCustomFieldSetting> AddDateCustomFieldAsync(AddDateCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<IssueType> AddIssueTypeAsync(AddIssueTypeParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CustomFieldSetting> AddListCustomFieldItemAsync(object projectIdOrKey, object CustomFieldId, string name, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> AddMilestoneAsync(AddMilestoneParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<MultipleListCustomFieldSetting> AddMultipleListCustomFieldAsync(AddMultipleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<NumericCustomFieldSetting> AddNumericCustomFieldAsync(AddNumericCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> AddProjectAdministratorAsync(object projectIdOrKey, object userId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> AddProjectUserAsync(object projectIdOrKey, object userId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<RadioCustomFieldSetting> AddRadioCustomFieldAsync(AddRadioCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SingleListCustomFieldSetting> AddSingleListCustomFieldAsync(AddSingleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<TextAreaCustomFieldSetting> AddTextAreaCustomFieldAsync(AddTextAreaCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<TextCustomFieldSetting> AddTextCustomFieldAsync(AddTextCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Version> AddVersionAsync(AddVersionParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Project> CreateProjectAsync(CreateProjectParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Project> DeleteProjectAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SharedFileData> DownloadSharedFileAsync(object projectIdOrKey, object sharedFileId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Category>> GetCategoriesAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<CustomFieldSetting>> GetCustomFieldsAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<IssueType>> GetIssueTypesAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Milestone>> GetMilestonesAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Activity>> GetProjectActivitiesAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Activity>> GetProjectActivitiesAsync(object projectIdOrKey, ActivityQueryParams query, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<User>> GetProjectAdministratorsAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<DiskUsageDetail> GetProjectDiskUsageAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Icon> GetProjectIconAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Project>> GetProjectsAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<User>> GetProjectUsersAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> GetSharedFilesAsync(object projectIdOrKey, string path, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> GetSharedFilesAsync(object projectIdOrKey, string path, QueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Version>> GetVersionsAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Category> RemoveCategoryAsync(object projectIdOrKey, object CategoryId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CustomFieldSetting> RemoveCustomFieldAsync(object projectIdOrKey, object CustomFieldId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<IssueType> RemoveIssueTypeAsync(object projectIdOrKey, object issueTypeId, object substituteIssueTypeId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CustomFieldSetting> RemoveListCustomFieldItemAsync(object projectIdOrKey, object CustomFieldId, object itemId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> RemoveMilestoneAsync(object projectIdOrKey, object MilestoneId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> RemoveProjectAdministratorAsync(object projectIdOrKey, object userId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> RemoveProjectUserAsync(object projectIdOrKey, object userId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Version> RemoveVersionAsync(object projectIdOrKey, object versionId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(UpdateCategoryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CheckBoxCustomFieldSetting> UpdateCheckBoxCustomFieldAsync(UpdateCheckBoxCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<DateCustomFieldSetting> UpdateDateCustomFieldAsync(UpdateDateCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<IssueType> UpdateIssueTypeAsync(UpdateIssueTypeParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<CustomFieldSetting> UpdateListCustomFieldItemAsync(object projectIdOrKey, object CustomFieldId, object itemId, string name, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> UpdateMilestoneAsync(UpdateMilestoneParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<MultipleListCustomFieldSetting> UpdateMultipleListCustomFieldAsync(UpdateMultipleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<NumericCustomFieldSetting> UpdateNumericCustomFieldAsync(UpdateNumericCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateProjectAsync(UpdateProjectParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<RadioCustomFieldSetting> UpdateRadioCustomFieldAsync(UpdateRadioCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SingleListCustomFieldSetting> UpdateSingleListCustomFieldAsync(UpdateSingleListCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<TextAreaCustomFieldSetting> UpdateTextAreaCustomFieldAsync(UpdateTextAreaCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<TextCustomFieldSetting> UpdateTextCustomFieldAsync(UpdateTextCustomFieldParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Version> UpdateVersionAsync(UpdateVersionParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
