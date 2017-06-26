using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public abstract class CustomField
    {
        private object customFieldId;

        public CustomField(object customFieldId)
        {
            this.customFieldId = customFieldId;
        }

        public string CustomFieldId => customFieldId.ToString();

        public static CustomFieldValue Text(long customFieldId, string customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue TextArea(long customFieldId, string customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue Numeric(long customFieldId, float customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue Numeric(long customFieldId, decimal customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldValue Date(long customFieldId, string customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue);

        public static CustomFieldItem SingleList(long customFieldId, long customFieldItemId) => new CustomFieldItem(customFieldId, customFieldItemId);

        public static CustomFieldItem Radio(long customFieldId, long customFieldItemId) => new CustomFieldItem(customFieldId, customFieldItemId);

        public static CustomFieldItems MultipleList(long customFieldId, IList<long> customFieldItemId) => new CustomFieldItems(customFieldId, customFieldItemId.Cast<object>().ToArray());

        public static CustomFieldItems CheckBox(long customFieldId, IList<long> customFieldItemId) => new CustomFieldItems(customFieldId, customFieldItemId.Cast<object>().ToArray());

        public static CustomFieldValue OtherValue(long customFieldId, object customFieldValue) => new CustomFieldValue(customFieldId, customFieldValue, isOtherValue: true);
    }

    public sealed class CustomFieldItem : CustomField
    {
        private object customFieldItemId;

        internal CustomFieldItem(object customFieldId, object customFieldItemId)
            : base(customFieldId)
        {
            this.customFieldItemId = customFieldItemId;
        }


        public string CustomFieldItemId => customFieldItemId == null ? "" : customFieldItemId.ToString();
    }

    public sealed class CustomFieldItems : CustomField
    {
        internal CustomFieldItems(object customFieldId, IList<object> customFieldItemIds)
            : base(customFieldId)
        {
            this.CustomFieldItemIds = new List<string>(customFieldItemIds.Select(x => x.ToString()));
        }


        public List<string> CustomFieldItemIds { get; private set; }
    }

    public sealed class CustomFieldValue : CustomField
    {
        private object customFieldValue;
        internal CustomFieldValue(object customFieldId, object customFieldValue, bool isOtherValue = false)
            : base(customFieldId)
        {
            this.customFieldValue = customFieldValue;
            this.IsOtherValue = isOtherValue;
        }

        public object Value => customFieldValue;

        public bool IsOtherValue { get; private set; }
    }

}
