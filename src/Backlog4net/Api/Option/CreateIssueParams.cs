using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateIssueParams : PostParams
    {
        public CreateIssueParams(object projectId, string summary, object issueTypeId, IssuePriorityType priority)
        {
            AddNewParam("projectId", projectId);
            AddNewParam("summary", summary);
            AddNewParam("issueTypeId", issueTypeId);
            AddNewParam("priorityId", priority.ToString("D"));
        }

        public object ParentIssueId { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public string StartDate { set => AddNewParamValue(value); }

        public string DueDate { set => AddNewParamValue(value); }

        public float EstimatedHours { set => AddNewParamValue(value); }

        public decimal? EstimatedHoursDecimal { set => AddNewParam("estimatedHours", value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2"): ""); }

        public float ActualHours { set => AddNewParamValue(value); }

        public decimal? ActualHoursDecimal { set => AddNewParam("actualHours", value != null ? Math.Round(value.Value, 2, MidpointRounding.AwayFromZero).ToString("F2") : ""); }

        public IList<object> CategoryIds { set => AddNewArrayParams("categoryId[]", value); }

        public IList<object> VersionIds { set => AddNewArrayParams("versionId[]", value); }

        public IList<object> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value); }

        public object AssigneeId { set => AddNewParamValue(value); }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<object> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<object> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }

        //public CustomFiledValue TextCustomField { set => AddNewParam($"customField_{value.CustomFieldId}", value.CustomFieldValue); }

        //public IList<CustomFiledValue> TextCustomFields
        //{
        //    set
        //    {
        //        foreach (var field in value) TextCustomField = field;
        //    }
        //}

        //public CustomFiledValue TextAreaCustomField { set => TextCustomField = value; }

        //public IList<CustomFiledValue> TextAreaCustomFields { set => TextCustomFields = value; }

        //public CustomFiledValue NumericCustomField { set => TextCustomField = value; }

        //public IList<CustomFiledValue> NumericCustomFields { set => TextCustomFields = value; }

        //public CustomFiledValue DateCustomField { set => TextCustomField = value; }

        //public IList<CustomFiledValue> DateCustomFields { set => TextCustomFields = value; }

        //public CustomFiledItem SingleListCustomField { set => AddNewParam($"customField_{value.CustomFieldId}", value.CustomFieldItemId ); }

        //public IList<CustomFiledItem> SingleListCustomFields
        //{
        //    set
        //    {
        //        foreach (var field in value) SingleListCustomField = field;
        //    }
        //}

        //public CustomFiledItem RadioCustomField { set => SingleListCustomField = value; }

        //public IList<CustomFiledItem> RadioCustomFields { set => SingleListCustomFields = value; }

        //public CustomFiledItems MultipleListCustomField
        //{
        //    set
        //    {
        //        var name = $"customField_{value.CustomFieldId}";
        //        foreach (var item in value.CustomFieldItemIds) AddNewParam(name, item);
        //    }
        //}

        //public IList<CustomFiledItems> MultipleListCustomFields
        //{
        //    set
        //    {
        //        foreach (var field in value) MultipleListCustomField = field;
        //    }
        //}

        //public CustomFiledItems CheckBoxCustomField { set => MultipleListCustomField = value; }

        //public IList<CustomFiledItems> CheckBoxCustomFields { set => MultipleListCustomFields = value; }

        //public CustomFiledValue CustomFieldOtherValue { set => AddNewParam($"customField_{value.CustomFieldId}_otherValue", value.CustomFieldValue); }

        //public IList<CustomFiledValue> CustomFieldOtherValues
        //{
        //    set
        //    {
        //        foreach (var field in value) TextCustomField = field;
        //    }
        //}
    }
}
