using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public abstract class CustomFieldSettingJsonImpl : CustomFieldSetting
    {
        internal class JsonConverter : MultiTypeConverter<CustomFieldSetting>
        {
            public JsonConverter() :
                base("fieldTypeId", new Dictionary<string, Type>
                {
                    { CustomFieldType.Text.ToString("D"), typeof(TextCustomFieldSetting) },
                    { CustomFieldType.TextArea.ToString("D"), typeof(TextAreaCustomFieldSetting) },
                    { CustomFieldType.Numeric.ToString("D"), typeof(NumericCustomFieldSetting) },
                    { CustomFieldType.Date.ToString("D"), typeof(DateCustomFieldSetting) },
                    { CustomFieldType.SingleList.ToString("D"), typeof(SingleListCustomFieldSetting) },
                    { CustomFieldType.MultipleList.ToString("D"), typeof(MultipleListCustomFieldSetting) },
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomFieldSetting) },
                    { CustomFieldType.Radio.ToString("D"), typeof(RadioCustomFieldSetting) },
                })
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public long[] ApplicableIssueTypes { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public bool IsRequired { get; private set; }

        [JsonProperty("fieldTypeId")]
        public abstract CustomFieldType FieldType { get; }
    }
}
