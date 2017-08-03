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
                base("typeId", new Dictionary<string, Type>
                {
                    { CustomFieldType.Text.ToString("D"), typeof(TextCustomFieldSettingJsonImpl) },
                    { CustomFieldType.TextArea.ToString("D"), typeof(TextAreaCustomFieldSettingJsonImpl) },
                    { CustomFieldType.Numeric.ToString("D"), typeof(NumericCustomFieldSettingJsonImpl) },
                    { CustomFieldType.Date.ToString("D"), typeof(DateCustomFieldSettingJsonImpl) },
                    { CustomFieldType.SingleList.ToString("D"), typeof(SingleListCustomFieldSettingJsonImpl) },
                    { CustomFieldType.MultipleList.ToString("D"), typeof(MultipleListCustomFieldSettingJsonImpl) },
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomFieldSettingJsonImpl) },
                    { CustomFieldType.Radio.ToString("D"), typeof(RadioCustomFieldSettingJsonImpl) },
                })
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public long[] ApplicableIssueTypes { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty("required")]
        public bool IsRequired { get; private set; }

        [JsonProperty("typeId")]
        public abstract CustomFieldType FieldType { get; }
    }
}
