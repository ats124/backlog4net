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
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomFieldSetting) }
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
