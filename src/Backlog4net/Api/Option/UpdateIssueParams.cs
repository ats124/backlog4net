﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueParams : PatchParams
    {
        private object issueIdOrKey;

        public UpdateIssueParams(object issueIdOrKey)
        {
            this.issueIdOrKey = issueIdOrKey;
        }

        /// <summary>
        /// Returns the issue identifier string.
        /// </summary>
        public string IssueIdOrKeyString => issueIdOrKey.ToString();

        public string Summary { set => AddNewParamValue(value); }

        public long? ParentIssueId { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public IssueStatusType Status { set => AddNewParamValue(value.ToString("D")); }

        public IssueResolutionType? Resolution { set => AddNewParamValue(value.HasValue ? value.Value.ToString("D") : ""); }

        public string StartDate { set => AddNewParamValue(value); }

        public string DueDate { set => AddNewParamValue(value); }

        public float EstimatedHours { set => AddNewParamValue(value); }

        public decimal? EstimatedHoursDecimal { set => AddNewParam("estimatedHours", value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2"): ""); }

        public float ActualHours { set => AddNewParamValue(value); }

        public decimal? ActualHoursDecimal { set => AddNewParam("actualHours", value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2") : ""); }

        public object IssueTypeId { set => AddNewParamValue(value); }

        public IList<object> CategoryIds { set => AddNewArrayParams("categoryId[]", value, isEmptySetBlank: true); }

        public IList<object> VersionIds { set => AddNewArrayParams("versionId[]", value, isEmptySetBlank: true); }

        public IList<object> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value, isEmptySetBlank: true); }

        public object AssigneeId
        {
            set => AddNewParamValue(value is int i 
                ? i <= 0 
                    ? ""
                    : i.ToString()
                : value);
        }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<object> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<object> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }

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
