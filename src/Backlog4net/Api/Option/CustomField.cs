using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public abstract class CustomField
    {
        protected CustomField(long customFieldId)
        {
            this.CustomFieldId = customFieldId;
        }

        public long CustomFieldId { get; private set; }

        public static CustomFieldValue Text(long customFieldId, string customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue TextArea(long customFieldId, string customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue Numeric(long customFieldId, decimal? customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue Date(long customFieldId, DateTime? customFieldValue) => new CustomFieldValue(customFieldId, ParamsBase.ToDateString(customFieldValue));

        public static CustomFieldItem SingleList(long customFieldId, long customFieldItemId) => new CustomFieldItem(customFieldId, customFieldItemId);

        public static CustomFieldItem Radio(long customFieldId, long customFieldItemId) => new CustomFieldItem(customFieldId, customFieldItemId);

        public static CustomFieldItems MultipleList(long customFieldId, params long[] customFieldItemIds) => new CustomFieldItems(customFieldId, customFieldItemIds);

        public static CustomFieldItems CheckBox(long customFieldId, params long[] customFieldItemIds) => new CustomFieldItems(customFieldId, customFieldItemIds);

        public static CustomFieldValue OtherValue(long customFieldId, object customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue, isOtherValue: true);
    }

    public sealed class CustomFieldItem : CustomField
    {
        internal CustomFieldItem(long customFieldId, long? customFieldItemId)
            : base(customFieldId)
        {
            this.CustomFieldItemId = customFieldItemId;
        }


        public long? CustomFieldItemId { get; private set; }
    }

    public sealed class CustomFieldItems : CustomField
    {
        internal CustomFieldItems(long customFieldId, IList<long> customFieldItemIds)
            : base(customFieldId)
        {
            this.CustomFieldItemIds = new List<string>(customFieldItemIds.Select(x => x.ToString()));
        }


        public List<string> CustomFieldItemIds { get; private set; }
    }

    public sealed class CustomFieldValue : CustomField
    {
        internal CustomFieldValue(long customFieldId, object customFieldValue, bool isOtherValue = false)
            : base(customFieldId)
        {
            this.Value = customFieldValue;
            this.IsOtherValue = isOtherValue;
        }

        public object Value { get; private set; }

        public bool IsOtherValue { get; private set; }
    }

}
