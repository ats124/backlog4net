using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetIssuesParams : GetParams
    {
        public GetIssuesParams(params object[] projectIds)
        {
            AddNewArrayParams("projectId[]", projectIds);
        }

        public IList<object> IssueTypeIds { set => AddNewArrayParams("issueTypeId[]", value); }

        public IList<object> CategoryIds { set => AddNewArrayParams("categoryId[]", value); }

        public IList<object> VersionIds { set => AddNewArrayParams("versionId[]", value); }

        public IList<object> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value); }

        public IList<IssueStatusType> Statuses { set => AddNewArrayParams("statusId[]", value, x => x.ToString("D")); }

        public IList<IssuePriorityType> Priorities { set => AddNewArrayParams("priorityId[]", value, x => x.ToString("D")); }

        public IList<object> AssigneeIds { set => AddNewArrayParams("assigneeId[]", value); }

        public IList<object> CreatedUserIds { set => AddNewArrayParams("createdUserId[]", value); }

        public IList<IssueResolutionType> Resolutions { set => AddNewArrayParams("resolutionId[]", value, x => x.ToString("D")); }

        public GetIssuesParentChildType ParentChildType { set => AddNewParam("parentChild", value.ToString("D")); }

        public bool Attachment { set => AddNewParamValue(value); }

        public bool SharedFile { set => AddNewParamValue(value); }

        public GetIssuesSortKey Sort { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public Order Order { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public long Offset { set => AddNewParamValue(value); }

        public long Count { set => AddNewParamValue(value); }

        public DateTime CreatedSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime CreatedUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime UpdatedSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime UpdatedUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime StartDateSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime StartDateUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime DueDateSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime DueDateUntil { set => AddNewParamValue(ToDateString(value)); }

        public IList<object> Ids { set => AddNewArrayParams("id[]", value); }

        public IList<object> ParentIssueIds { set => AddNewArrayParams("parentIssueId[]", value); }

        public string Keyword { set => AddNewParamValue(value); }

        public IList<GetIssuesCustomField> CustomFields
        {
            set
            {
                if (value != null)
                {
                    foreach (var param in value.SelectMany(x => x.Parameters)) { this.Parameters.Add(param); }
                }
            }
        }
    }

    public class GetIssuesCustomField : ParamsBase
    {
        public object CustomFieldId { get; private set; }

        private GetIssuesCustomField(object customFieldId)
        {
            this.CustomFieldId = customFieldId;
        }
        private void AddNewParamValueCustomField(object value, string postfix) => AddNewParam("customField_" + CustomFieldId + postfix, value);

        public static GetIssuesCustomField ByKeyword(object customFieldId, string value)
        {
            var obj = new GetIssuesCustomField(customFieldId);
            obj.AddNewParamValueCustomField(value, "");
            return obj;
        }

        public static GetIssuesCustomField ByNumeric(object customFieldId, decimal? minValue = null, decimal? maxValue = null)
        {
            var obj = new GetIssuesCustomField(customFieldId);
            if (minValue.HasValue) obj.AddNewParamValueCustomField(minValue.Value, "_min");
            if (maxValue.HasValue) obj.AddNewParamValueCustomField(maxValue.Value, "_max");
            return obj;
        }

        public static GetIssuesCustomField ByDate(object customFieldId, DateTime? minValue = null, DateTime? maxValue = null)
        {
            var obj = new GetIssuesCustomField(customFieldId);
            if (minValue.HasValue) obj.AddNewParamValueCustomField(ToDateString(minValue), "_min");
            if (maxValue.HasValue) obj.AddNewParamValueCustomField(ToDateString(maxValue), "_max");
            return obj;
        }

        public static GetIssuesCustomField ByItems(object customFieldId, params long[] itemIds)
        {
            var obj = new GetIssuesCustomField(customFieldId);
            obj.AddNewArrayParams("customField_" + customFieldId + "[]", itemIds);
            return obj;
        }
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
}
