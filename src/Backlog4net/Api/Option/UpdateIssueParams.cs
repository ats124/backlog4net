using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueParams : PatchParams
    {
        public UpdateIssueParams(IdOrKey issueIdOrKey)
        {
            this.IssueIdOrKey = issueIdOrKey;
        }

        /// <summary>
        /// Returns the issue identifier string.
        /// </summary>
        public IdOrKey IssueIdOrKey { get; private set; }

        public string Summary { set => AddNewParamValue(value); }

        public long? ParentIssueId { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public IssueStatusType Status { set => AddNewParam("statusId", value.ToString("D")); }

        public IssueResolutionType? Resolution { set => AddNewParam("resolutionId", value.HasValue ? value.Value.ToString("D") : ""); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? DueDate { set => AddNewParamValue(ToDateString(value)); }

        public decimal? EstimatedHours { set => AddNewParamValue(value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2"): ""); }

        public decimal? ActualHours { set => AddNewParamValue(value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2") : ""); }

        public long IssueTypeId { set => AddNewParamValue(value); }

        public IssuePriorityType Priority { set => AddNewParam("priorityId", value.ToString("D")); }

        public IList<long> CategoryIds { set => AddNewArrayParams("categoryId[]", value, isEmptySetBlank: true); }

        public IList<long> VersionIds { set => AddNewArrayParams("versionId[]", value, isEmptySetBlank: true); }

        public IList<long> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value, isEmptySetBlank: true); }

        public long? AssigneeId { set => AddNewParamValue(value); }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<long> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<long> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }

        public IList<CustomField> CustomFields
        {
            set
            {
                if (value == null) return;
                foreach (var field in value)
                {
                    var name = "customField_" + field.CustomFieldId;
                    switch (field)
                    {
                        case CustomFieldValue fieldValue:
                            if (fieldValue.IsOtherValue) name = name + "_otherValue";
                            switch (fieldValue.Value)
                            {
                                case null: AddNewParam(name, ""); break;
                                case string strValue: AddNewParam(name, strValue); break;
                                case decimal decValue: AddNewParam(name, Math.Round(decValue, 2, MidpointRounding.AwayFromZero).ToString("F4")); break;
                                default: AddNewParam(name, fieldValue.Value); break;
                            }
                            break;
                        case CustomFieldItem fieldItem:
                            AddNewParam(name, fieldItem.CustomFieldItemId);
                            break;
                        case CustomFieldItems fieldItems:
                            foreach (var itemId in fieldItems.CustomFieldItemIds) AddNewParam(name, itemId);
                            break;
                    }
                }
            }
        }
    }
}
