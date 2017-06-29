using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    using Option;
    using Internal.Json.CustomFields;

    /// <summary>
    /// Executes Backlog Project APIs.
    /// </summary>
    public interface ProjectMethods
    {
        /// <summary>
        /// Returns all the projects.
        /// </summary>
        /// <returns>the projects in a list.</returns>
        ResponseList<Project> GetProjects();

        /// <summary>
        /// Create a project.
        /// </summary>
        /// <param name="params">the Creating project parameters.</param>
        /// <returns>the Created project</returns>
        Project CreateProject(CreateProjectParams @params);

        /// <summary>
        /// Returns the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Project</returns>
        Project GetProject(object projectIdOrKey);

        /// <summary>
        /// Updates the existing project.
        /// </summary>
        /// <param name="params">the updating project parameters</param>
        /// <returns>the updated Project</returns>
        Project UpdateProject(UpdateProjectParams @params);

        /// <summary>
        /// Deletes the existing project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the deleted Project</returns>
        Project DeleteProject(object projectIdOrKey);

        /// <summary>
        /// Returns the project icon.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Icon</returns>
        Icon GetProjectIcon(object projectIdOrKey);

        /// <summary>
        /// Returns the activities on the project.
        /// </summary>
        /// <param name="projectIdOrKey"> the project identifier</param>
        /// <returns>the activities in a list</returns>
        ResponseList<Activity> GetProjectActivities(object projectIdOrKey);

        /// <summary>
        /// Returns the activities on the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="query">the query parameters</param>
        /// <returns>the activities in a list</returns>
        ResponseList<Activity> GetProjectActivities(object projectIdOrKey, ActivityQueryParams query);

        /// <summary>
        /// Adds the user to the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the added User</returns>
        User AddProjectUser(object projectIdOrKey, object userId);

        /// <summary>
        /// Returns the users in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the users in a list.</returns>
        ResponseList<User> GetProjectUsers(object projectIdOrKey);

        /// <summary>
        /// Removes the user from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        User RemoveProjectUser(object projectIdOrKey, object userId);

        /// <summary>
        /// Adds the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        User AddProjectAdministrator(object projectIdOrKey, object userId);

        /// <summary>
        /// Returns the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the project administrators</returns>
        ResponseList<User> GetProjectAdministrators(object projectIdOrKey);

        /// <summary>
        /// Deletes the project administrators.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="userId">the user identifier</param>
        /// <returns>the removed User</returns>
        User RemoveProjectAdministrator(object projectIdOrKey, object userId);

        /// <summary>
        /// Returns the issue types in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the issue types in a list</returns>
        ResponseList<IssueType> GetIssueTypes(object projectIdOrKey);

        /// <summary>
        /// Adds a issue type to the project.
        /// </summary>
        /// <param name="params">the Creating issue type parameters</param>
        /// <returns>the added IssueType</returns>
        IssueType AddIssueType(AddIssueTypeParams @params);

        /// <summary>
        /// Updates the issue type in the project.
        /// </summary>
        /// <param name="params">the updating issue type parameters</param>
        /// <returns>the updated IssueType</returns>
        IssueType UpdateIssueType(UpdateIssueTypeParams @params);

        /// <summary>
        /// Removes the existing issue type from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="issueTypeId">the issue type identifier</param>
        /// <param name="substituteIssueTypeId">the substitute issue type identifier</param>
        /// <returns>the removed IssueType</returns>
        IssueType RemoveIssueType(object projectIdOrKey, object issueTypeId, object substituteIssueTypeId);

        /// <summary>
        /// Returns the Categories in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Categories in a list</returns>
        ResponseList<Category> GetCategories(object projectIdOrKey);

        /// <summary>
        /// Adds a Category to the project.
        /// </summary>
        /// <param name="params">the adding Category parameter</param>
        /// <returns>the added Category</returns>
        Category AddCategory(AddCategoryParams @params);

        /// <summary>
        /// Updates the existing Category in the project.
        /// </summary>
        /// <param name="params">the updating Category parameters.</param>
        /// <returns>the updated Category</returns>
        Category UpdateCategory(UpdateCategoryParams @params);

        /// <summary>
        /// Removes the Category from the project
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="CategoryId">the Category identifier</param>
        /// <returns>the removed Category</returns>
        Category RemoveCategory(object projectIdOrKey, object CategoryId);

        /// <summary>
        /// Returns the versions in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the versions in a list</returns>
        ResponseList<Version> GetVersions(object projectIdOrKey);

        /// <summary>
        /// Adds a version to the project.
        /// </summary>
        /// <param name="params">the adding version parameters.</param>
        /// <returns>the added version</returns>
        Version AddVersion(AddVersionParams @params);

        /// <summary>
        /// Updates the existing version in the project.
        /// </summary>
        /// <param name="params">the updating version parameters.</param>
        /// <returns>the updated version</returns>
        Version UpdateVersion(UpdateVersionParams @params);

        /// <summary>
        /// Removes the version from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="versionId">the version identifier</param>
        /// <returns>the removed version</returns>
        Version RemoveVersion(object projectIdOrKey, object versionId);

        /// <summary>
        /// Returns the Milestones in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Milestones in a list</returns>
        ResponseList<Milestone> GetMilestones(object projectIdOrKey);

        /// <summary>
        /// Adds a Milestone to the project.
        /// </summary>
        /// <param name="params">the adding Milestone parameters.</param>
        /// <returns>the added Milestone</returns>
        Milestone AddMilestone(AddMilestoneParams @params);

        /// <summary>
        /// Updates the existing Milestone in the project.
        /// </summary>
        /// <param name="params">the updating Milestone parameters.</param>
        /// <returns>the updated Milestone</returns>
        Milestone UpdateMilestone(UpdateMilestoneParams @params);

        /// <summary>
        /// Removes the Milestone from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="MilestoneId">the Milestone identifier</param>
        /// <returns></returns>
        Milestone RemoveMilestone(object projectIdOrKey, object MilestoneId);

        /// <summary>
        /// Returns the Custom fields in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Custom fields in a list</returns>
        ResponseList<CustomFieldSetting> GetCustomFields(object projectIdOrKey);

        /// <summary>
        /// Adds a text type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding text type Custom filed parameters.</param>
        /// <returns>the added text type Custom field setting.</returns>
        TextCustomFieldSetting AddTextCustomField(AddTextCustomFieldParams @params);

        /// <summary>
        /// Adds a text area type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding text area type Custom filed parameters.</param>
        /// <returns>the added text area type Custom field setting.</returns>
        TextAreaCustomFieldSetting AddTextAreaCustomField(AddTextAreaCustomFieldParams @params);

        /// <summary>
        /// Adds a numeric type Custom field to the project.
        /// </summary>
        /// <param name="params">adding numeric type Custom filed parameters.</param>
        /// <returns>the added numeric type Custom field setting.</returns>
        NumericCustomFieldSetting AddNumericCustomField(AddNumericCustomFieldParams @params);

        /// <summary>
        /// Adds a date type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding date type Custom filed parameters.</param>
        /// <returns>the added date type Custom field setting.</returns>
        DateCustomFieldSetting AddDateCustomField(AddDateCustomFieldParams @params);

        /// <summary>
        /// Adds a single list type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding single list type Custom filed parameters.</param>
        /// <returns>the added single list type Custom field setting.</returns>
        SingleListCustomFieldSetting AddSingleListCustomField(AddSingleListCustomFieldParams @params);

        /// <summary>
        /// Adds a multiple list type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding multiple list type Custom filed parameters.</param>
        /// <returns>the added multiple list type Custom field setting.</returns>
        MultipleListCustomFieldSetting AddMultipleListCustomField(AddMultipleListCustomFieldParams @params);

        /// <summary>
        /// Adds a radio type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding radio type Custom filed parameters.</param>
        /// <returns>the added radio type Custom field setting.</returns>
        RadioCustomFieldSetting AddRadioCustomField(AddRadioCustomFieldParams @params);

        /// <summary>
        /// Adds a Checkbox type Custom field to the project.
        /// </summary>
        /// <param name="params">the adding Checkbox type Custom filed parameters.</param>
        /// <returns>the added Checkbox type Custom field setting.</returns>
        CheckBoxCustomFieldSetting AddCheckBoxCustomField(AddCheckBoxCustomFieldParams @params);

        /// <summary>
        /// Updates the existing text type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating text type Custom filed parameters.</param>
        /// <returns>the updated text type Custom field setting.</returns>
        TextCustomFieldSetting UpdateTextCustomField(UpdateTextCustomFieldParams @params);

        /// <summary>
        /// Updates the existing text area type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating text area type Custom filed parameters.</param>
        /// <returns>the updated text area type Custom field setting.</returns>
        TextAreaCustomFieldSetting UpdateTextAreaCustomField(UpdateTextAreaCustomFieldParams @params);

        /// <summary>
        /// Updates the existing numeric type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating numeric type Custom filed parameters.</param>
        /// <returns>the updated numeric type Custom field setting.</returns>
        NumericCustomFieldSetting UpdateNumericCustomField(UpdateNumericCustomFieldParams @params);

        /// <summary>
        /// Updates the existing date type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating date type Custom filed parameters.</param>
        /// <returns>the updated date type Custom field setting.</returns>
        DateCustomFieldSetting UpdateDateCustomField(UpdateDateCustomFieldParams @params);

        /// <summary>
        /// Updates the existing single list type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating single list type Custom filed parameters.</param>
        /// <returns>the updated single list type Custom field setting.</returns>
        SingleListCustomFieldSetting UpdateSingleListCustomField(UpdateSingleListCustomFieldParams @params);

        /// <summary>
        /// Updates the existing multiple list type Custom field in the project.
        /// </summary>
        /// <param name="params">the multiple list text type Custom filed parameters.</param>
        /// <returns>the updated multiple list type Custom field setting.</returns>
        MultipleListCustomFieldSetting UpdateMultipleListCustomField(UpdateMultipleListCustomFieldParams @params);

        /// <summary>
        /// Updates the existing radio type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating radio type Custom filed parameters.</param>
        /// <returns>the updated radio type Custom field setting.</returns>
        RadioCustomFieldSetting UpdateRadioCustomField(UpdateRadioCustomFieldParams @params);

        /// <summary>
        /// Updates the existing Checkbox type Custom field in the project.
        /// </summary>
        /// <param name="params">the updating Checkbox type Custom filed parameters.</param>
        /// <returns>the updated Checkbox type Custom field setting.</returns>
        CheckBoxCustomFieldSetting UpdateCheckBoxCustomField(UpdateCheckBoxCustomFieldParams @params);

        /// <summary>
        /// Removes the Custom filed from the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="CustomFieldId">the Custom field identifier</param>
        /// <returns>the removed Custom filed</returns>
        CustomFieldSetting RemoveCustomField(object projectIdOrKey, object CustomFieldId);

        /// <summary>
        /// Adds a item to the list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="CustomFieldId">the Custom field identifier</param>
        /// <param name="name">name of the adding item</param>
        /// <returns>the added Custom filed item</returns>
        CustomFieldSetting AddListCustomFieldItem(object projectIdOrKey, object CustomFieldId, string name);

        /// <summary>
        /// Updates the existing item of list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="CustomFieldId">the Custom field identifier</param>
        /// <param name="itemId">the item identifier</param>
        /// <param name="name">name of the updating item</param>
        /// <returns>the updated CustomFieldSetting</returns>
        CustomFieldSetting UpdateListCustomFieldItem(object projectIdOrKey, object CustomFieldId, object itemId, string name);

        /// <summary>
        /// Removes the item of list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="CustomFieldId">the Custom field identifier</param>
        /// <param name="itemId">the item identifier</param>
        /// <returns>the removed CustomFieldSetting</returns>
        CustomFieldSetting RemoveListCustomFieldItem(object projectIdOrKey, object CustomFieldId, object itemId);

        /// <summary>
        /// Removes the item of list type Custom field.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="path">path of the shared file directory</param>
        /// <returns>the shared files in a list</returns>
        ResponseList<SharedFile> GetSharedFiles(object projectIdOrKey, string path);

        /// <summary>
        /// Returns the shared files in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="path">path of the shared file directory</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the shared files in a list</returns>
        ResponseList<SharedFile> GetSharedFiles(object projectIdOrKey, string path, QueryParams queryParams);

        /// <summary>
        /// Returns the shared file data in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="sharedFileId">the shared file identifier</param>
        /// <returns>the SharedFileData</returns>
        SharedFileData DownloadSharedFile(object projectIdOrKey, object sharedFileId);

        /// <summary>
        /// Returns the disk usage of the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the DiskUsageDetail</returns>
        DiskUsageDetail GetProjectDiskUsage(object projectIdOrKey);

    }
}
