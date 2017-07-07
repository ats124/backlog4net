using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetIssuesCountParams : GetParams
    {
        public GetIssuesCountParams(params object[] projectIds)
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

    public enum GetIssuesParentChildType
    {
        All = 0,
        NotChild = 1,
        Child = 2,
        NotChildNotParent = 3,
        Parent = 4
    }
}
