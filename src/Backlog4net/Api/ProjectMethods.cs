using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Project APIs.
    /// </summary>
    public interface ProjectMethods
    {
        /// <summary>
        /// Returns all the projects.
        /// </summary>
        /// <returns>the projects in a list.</returns>
        Task<ResponseList<Project>> GetProjectsAsync(CancellationToken? token = null);

        /// <summary>
        /// Create a project.
        /// </summary>
        /// <param name="params">the Creating project parameters.</param>
        /// <returns>the Created project</returns>
        Task<Project> CreateProjectAsync(CreateProjectParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Project</returns>
        Task<Project> GetProjectAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing project.
        /// </summary>
        /// <param name="params">the updating project parameters</param>
        /// <returns>the updated Project</returns>
        Task<Project> UpdateProjectAsync(UpdateProjectParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the existing project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the deleted Project</returns>
        Task<Project> DeleteProjectAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the project icon.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Icon</returns>
        Task<Icon> GetProjectIconAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the activities on the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="query">the query parameters</param>
        /// <returns>the activities in a list</returns>
        Task<ResponseList<Activity>> GetProjectActivitiesAsync(IdOrKey projectIdOrKey, ActivityQueryParams query = null, CancellationToken? token = null);

        /// <summary>
        /// Adds the user to the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the added User</returns>
        Task<User> AddProjectUserAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = null);

        /// <summary>
        /// Returns the users in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the users in a list.</returns>
        Task<ResponseList<User>> GetProjectUsersAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Removes the user from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        Task<User> RemoveProjectUserAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = null);

        /// <summary>
        /// Adds the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        Task<User> AddProjectAdministratorAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = null);

        /// <summary>
        /// Returns the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the project administrators</returns>
        Task<ResponseList<User>> GetProjectAdministratorsAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Deletes the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        Task<User> RemoveProjectAdministratorAsync(IdOrKey projectIdOrKey, long userId, CancellationToken? token = null);

        /// <summary>
        /// Returns the issue types in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the issue types in a list</returns>
        Task<ResponseList<IssueType>> GetIssueTypesAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Adds a issue type to the project.
        /// </summary>
        /// <param name="params">the Creating issue type parameters</param>
        /// <returns>the added IssueType</returns>
        Task<IssueType> AddIssueTypeAsync(AddIssueTypeParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the issue type in the project.
        /// </summary>
        /// <param name="params">the updating issue type parameters</param>
        /// <returns>the updated IssueType</returns>
        Task<IssueType> UpdateIssueTypeAsync(UpdateIssueTypeParams @params, CancellationToken? token = null);

        /// <summary>
        /// Removes the existing issue type from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="issueTypeId">the issue type identifier</param>
        /// <param name="substituteIssueTypeId">the substitute issue type identifier</param>
        /// <returns>the removed IssueType</returns>
        Task<IssueType> RemoveIssueTypeAsync(IdOrKey projectIdOrKey, long issueTypeId, long substituteIssueTypeId, CancellationToken? token = null);

        /// <summary>
        /// Returns the Categories in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Categories in a list</returns>
        Task<ResponseList<Category>> GetCategoriesAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Adds a Category to the project.
        /// </summary>
        /// <param name="params">the adding Category parameter</param>
        /// <returns>the added Category</returns>
        Task<Category> AddCategoryAsync(AddCategoryParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing Category in the project.
        /// </summary>
        /// <param name="params">the updating Category parameters.</param>
        /// <returns>the updated Category</returns>
        Task<Category> UpdateCategoryAsync(UpdateCategoryParams @params, CancellationToken? token = null);

        /// <summary>
        /// Removes the Category from the project
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="categoryId">the Category identifier</param>
        /// <returns>the removed Category</returns>
        Task<Category> RemoveCategoryAsync(IdOrKey projectIdOrKey, long categoryId, CancellationToken? token = null);

        /// <summary>
        /// Returns the versions in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the versions in a list</returns>
        Task<ResponseList<Version>> GetVersionsAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Adds a version to the project.
        /// </summary>
        /// <param name="params">the adding version parameters.</param>
        /// <returns>the added version</returns>
        Task<Version> AddVersionAsync(AddVersionParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing version in the project.
        /// </summary>
        /// <param name="params">the updating version parameters.</param>
        /// <returns>the updated version</returns>
        Task<Version> UpdateVersionAsync(UpdateVersionParams @params, CancellationToken? token = null);

        /// <summary>
        /// Removes the version from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="versionId">the version identifier</param>
        /// <returns>the removed version</returns>
        Task<Version> RemoveVersionAsync(IdOrKey projectIdOrKey, long versionId, CancellationToken? token = null);

        /// <summary>
        /// Returns the Milestones in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Milestones in a list</returns>
        Task<ResponseList<Milestone>> GetMilestonesAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Adds a Milestone to the project.
        /// </summary>
        /// <param name="params">the adding Milestone parameters.</param>
        /// <returns>the added Milestone</returns>
        Task<Milestone> AddMilestoneAsync(AddMilestoneParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing Milestone in the project.
        /// </summary>
        /// <param name="params">the updating Milestone parameters.</param>
        /// <returns>the updated Milestone</returns>
        Task<Milestone> UpdateMilestoneAsync(UpdateMilestoneParams @params, CancellationToken? token = null);

        /// <summary>
        /// Removes the Milestone from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="MilestoneId">the Milestone identifier</param>
        /// <returns></returns>
        Task<Milestone> RemoveMilestoneAsync(IdOrKey projectIdOrKey, long MilestoneId, CancellationToken? token = null);

        /// <summary>
        /// Returns the Custom fields in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Custom fields in a list</returns>
        Task<ResponseList<CustomFieldSetting>> GetCustomFieldsAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Adds a text type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding text type Custom filed parameters.</param>
        /// <returns>the added text type Custom field setting.</returns>
        Task<TextCustomFieldSetting> AddTextCustomFieldAsync(AddTextCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a text area type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding text area type Custom filed parameters.</param>
        /// <returns>the added text area type Custom field setting.</returns>
        Task<TextAreaCustomFieldSetting> AddTextAreaCustomFieldAsync(AddTextAreaCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a numeric type Custom field to the project.
        /// </summary>
        /// <param name="params">adding numeric type Custom filed parameters.</param>
        /// <returns>the added numeric type Custom field setting.</returns>
        Task<NumericCustomFieldSetting> AddNumericCustomFieldAsync(AddNumericCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a date type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding date type Custom filed parameters.</param>
        /// <returns>the added date type Custom field setting.</returns>
        Task<DateCustomFieldSetting> AddDateCustomFieldAsync(AddDateCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a single list type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding single list type Custom filed parameters.</param>
        /// <returns>the added single list type Custom field setting.</returns>
        Task<SingleListCustomFieldSetting> AddSingleListCustomFieldAsync(AddSingleListCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a multiple list type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding multiple list type Custom filed parameters.</param>
        /// <returns>the added multiple list type Custom field setting.</returns>
        Task<MultipleListCustomFieldSetting> AddMultipleListCustomFieldAsync(AddMultipleListCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a radio type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding radio type Custom filed parameters.</param>
        /// <returns>the added radio type Custom field setting.</returns>
        Task<RadioCustomFieldSetting> AddRadioCustomFieldAsync(AddRadioCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Adds a Checkbox type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding Checkbox type Custom filed parameters.</param>
        /// <returns>the added Checkbox type Custom field setting.</returns>
        Task<CheckBoxCustomFieldSetting> AddCheckBoxCustomFieldAsync(AddCheckBoxCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing text type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating text type Custom filed parameters.</param>
        /// <returns>the updated text type Custom field setting.</returns>
        Task<TextCustomFieldSetting> UpdateTextCustomFieldAsync(UpdateTextCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing text area type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating text area type Custom filed parameters.</param>
        /// <returns>the updated text area type Custom field setting.</returns>
        Task<TextAreaCustomFieldSetting> UpdateTextAreaCustomFieldAsync(UpdateTextAreaCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing numeric type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating numeric type Custom filed parameters.</param>
        /// <returns>the updated numeric type Custom field setting.</returns>
        Task<NumericCustomFieldSetting> UpdateNumericCustomFieldAsync(UpdateNumericCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing date type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating date type Custom filed parameters.</param>
        /// <returns>the updated date type Custom field setting.</returns>
        Task<DateCustomFieldSetting> UpdateDateCustomFieldAsync(UpdateDateCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing single list type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating single list type Custom filed parameters.</param>
        /// <returns>the updated single list type Custom field setting.</returns>
        Task<SingleListCustomFieldSetting> UpdateSingleListCustomFieldAsync(UpdateSingleListCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing multiple list type Custom field in the project.
        /// </summary>
        /// <param name="params">the multiple list text type Custom filed parameters.</param>
        /// <returns>the updated multiple list type Custom field setting.</returns>
        Task<MultipleListCustomFieldSetting> UpdateMultipleListCustomFieldAsync(UpdateMultipleListCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing radio type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating radio type Custom filed parameters.</param>
        /// <returns>the updated radio type Custom field setting.</returns>
        Task<RadioCustomFieldSetting> UpdateRadioCustomFieldAsync(UpdateRadioCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing Checkbox type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating Checkbox type Custom filed parameters.</param>
        /// <returns>the updated Checkbox type Custom field setting.</returns>
        Task<CheckBoxCustomFieldSetting> UpdateCheckBoxCustomFieldAsync(UpdateCheckBoxCustomFieldParams @params, CancellationToken? token = null);

        /// <summary>
        /// Removes the Custom filed from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="customFieldId">the Custom field identifier</param>
        /// <returns>the removed Custom filed</returns>
        Task<CustomFieldSetting> RemoveCustomFieldAsync(IdOrKey projectIdOrKey, long customFieldId, CancellationToken? token = null);

        /// <summary>
        /// Adds a item to the list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="customFieldId">the Custom field identifier</param>
        /// <param name="name">name of the adding item</param>
        /// <returns>the added Custom filed item</returns>
        Task<CustomFieldSetting> AddListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, string name, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing item of list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="customFieldId">the Custom field identifier</param>
        /// <param name="itemId">the item identifier</param>
        /// <param name="name">name of the updating item</param>
        /// <returns>the updated CustomFieldSetting</returns>
        Task<CustomFieldSetting> UpdateListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, long itemId, string name, CancellationToken? token = null);

        /// <summary>
        /// Removes the item of list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="customFieldId">the Custom field identifier</param>
        /// <param name="itemId">the item identifier</param>
        /// <returns>the removed CustomFieldSetting</returns>
        Task<CustomFieldSetting> RemoveListCustomFieldItemAsync(IdOrKey projectIdOrKey, long customFieldId, long itemId, CancellationToken? token = null);

        /// <summary>
        /// Returns the shared files in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="path">path of the shared file directory</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the shared files in a list</returns>
        Task<ResponseList<SharedFile>> GetSharedFilesAsync(IdOrKey projectIdOrKey, string path, QueryParams queryParams = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the shared file data in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="sharedFileId">the shared file identifier</param>
        /// <returns>the SharedFileData</returns>
        Task<SharedFileData> DownloadSharedFileAsync(IdOrKey projectIdOrKey, long sharedFileId, CancellationToken? token = null);

        /// <summary>
        /// Returns the disk usage of the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the DiskUsageDetail</returns>
        Task<DiskUsageDetail> GetProjectDiskUsageAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

    }
}
