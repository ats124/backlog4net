﻿using System;
using System.Linq;
using System.Collections.Generic;
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

        public GetIssuesCustomField(object customFieldId)
        {
            this.CustomFieldId = customFieldId;
        }

        private void AddNewParamValueCustomField(object value, string postfix) => AddNewParam("customField_" + CustomFieldId + postfix, value);

        public string KeywordByCustomFiled { set => AddNewParamValueCustomField(value, ""); }

        public decimal MinNumOfCustomField { set => AddNewParamValueCustomField(value, "_min"); }

        public decimal MaxNumOfCustomField { set => AddNewParamValueCustomField(value, "_max"); }

        public DateTime MinDateOfCustomField { set => AddNewParamValueCustomField(ToDateString(value), "_min"); }

        public DateTime MaxDateOfCustomField { set => AddNewParamValueCustomField(ToDateString(value), "_max"); }

        public IList<object> ItemsOfCustomField { set => AddNewArrayParams("customField_" + CustomFieldId + "[]", value); }

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
