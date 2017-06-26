using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetIssuesParams : GetParams
    {
        public GetIssuesParams(IList<object> projectIds)
        {
            AddNewArrayParams("projectId[]", projectIds);
        }

        public IList<object> IssueTypeIds { set => AddNewArrayParams("issueTypeId[]", value); }

        public IList<object> CategoryIds { set => AddNewArrayParams("categoryId[]", value); }

        public IList<object> VersionIds { set => AddNewArrayParams("versionId[]", value); }

        public IList<object> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value); }

        public IList<IssueStatusType> Statuses { set => AddNewArrayParams("statusId[]", value, x => x.ToString("D")); }

        public IList<IssuePriorityType> Priorities { set => AddNewArrayParams("priorityId[]", value, x => x.ToString("D")); }

        public IList<object> AssignerIds { set => AddNewArrayParams("assignerId[]", value); }

        public IList<object> CreatedUserIds { set => AddNewArrayParams("createdUserId[]", value); }

        public IList<IssueResolutionType> Resolutions { set => AddNewArrayParams("resolutionId[]", value, x => x.ToString("D")); }

        public GetIssuesParentChildType ParentChildType { set => AddNewParamValue(value); }

        public bool Attachment { set => AddNewParamValue(value); }

        public bool SharedFile { set => AddNewParamValue(value); }

        public GetIssuesSortKey Sort { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public GetIssuesOrder Order { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public long Offset { set => AddNewParamValue(value); }

        public long Count { set => AddNewParamValue(value); }

        public string CreatedSince { set => AddNewParamValue(value); }

        public string CreatedUntil { set => AddNewParamValue(value); }

        public string UpdatedSince { set => AddNewParamValue(value); }

        public string UpdatedUntil { set => AddNewParamValue(value); }

        public string StartDateSince { set => AddNewParamValue(value); }

        public string StartDateUntil { set => AddNewParamValue(value); }

        public string DueDateSince { set => AddNewParamValue(value); }

        public string DueDateUntil { set => AddNewParamValue(value); }

        public IList<object> Ids { set => AddNewArrayParams("id[]", value); }

        public IList<object> ParentIssueIds { set => AddNewArrayParams("parentIssueId[]", value); }

        public string Keyword { set => AddNewParamValue(value); }

        private void AddNewParamValueCustomField((object CustomFieldId, object value) x, string postfix) => AddNewParam("customField_" + x.CustomFieldId + postfix, x.value);

        public (object CustomFieldId, string Keyword) KeywordByCustomFiled { set => AddNewParamValueCustomField(value, ""); }

        public (object CustomFieldId, float min) MinNumOfCustomField { set => AddNewParamValueCustomField(value, "_min"); }

        public (object CustomFieldId, float max) MaxNumOfCustomField { set => AddNewParamValueCustomField(value, "_max"); }

        public (object CustomFieldId, string min) MinDateOfCustomField { set => AddNewParamValueCustomField(value, "_min"); }

        public (object CustomFieldId, string max) MaxDateOfCustomField { set => AddNewParamValueCustomField(value, "_max"); }

        public (object CustomFieldId, IList<object> itemIds) ItemsOfCustomField { set => AddNewArrayParams("customField_" + value.CustomFieldId + "[]", value.itemIds); }
    }

    public enum GetIssuesSortKey
    {
        IssueType,
        Category,
        Version,
        Milestone,
        Summary,
        Status,
        Priority,
        Attachment,
        SharedFile,
        Created,
        CreatedUser,
        Updated,
        UpdatedUser,
        Assignee,
        StartDate,
        DueDate,
        EstimatedHours,
        ActualHours,
        ChildIssue,
    }

    public enum GetIssuesOrder
    {
        Asc,
        Desc,
    }
}
