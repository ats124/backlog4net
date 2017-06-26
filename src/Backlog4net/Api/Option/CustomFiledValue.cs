using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CustomFiledValue
    {
        private object customFieldId;
        private object customFieldValue;

        public CustomFiledValue(object customFieldId, object customFieldValue)
        {
            this.customFieldId = customFieldId;
            this.customFieldValue = customFieldValue;
        }

        public string CustomFieldId => customFieldId.ToString();
        
        public string CustomFieldValue => customFieldValue == null ? "" : customFieldValue.ToString();
    }

    public abstract class CustomFiledValueBase
    {
        private long customFieldId;

        public CustomFiledValueBase(long customFieldId)
        {
            this.customFieldId = customFieldId;
        }

        public string CustomFieldId => customFieldId.ToString();

        protected static string GetCustomFieldValueString(object value)
        {
            switch (value)
            {
                case null:
                    return "";
                case string str:
                    return str;
                case decimal dec:
                    return Math.Round(dec, 4, MidpointRounding.AwayFromZero).ToString("F4");
                default:
                    return value.ToString();
            }
        }
    }

    public abstract class CustomFiledSingleValueBase : CustomFiledValueBase
    {
        private object customFieldValue;

        public CustomFiledSingleValueBase(long customFieldId, object customFieldValue)
            : base(customFieldId)
        {
            this.customFieldValue = customFieldValue;
        }

        public string CustomFieldValue => GetCustomFieldValueString(customFieldValue);
    }

    public sealed class TextCustomFieldValue : CustomFiledSingleValueBase
    {
        public TextCustomFieldValue(long customFieldId, string customFieldValue) 
            : base(customFieldId, customFieldValue)
        {
        }
    }


}
