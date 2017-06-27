﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backlog4net.Internal.Json.CustomFields
{
    public abstract class CustomFieldJsonImpl : CustomField
    {
        internal class JsonConverter : MultiTypeConverter<CustomField>
        {
            public JsonConverter() : 
                base("fieldTypeId", new Dictionary<string, Type>
                {
                    { CustomFieldType.Text.ToString("D"), typeof(TextCustomField) },
                    { CustomFieldType.TextArea.ToString("D"), typeof(TextAreaCustomField) },
                    { CustomFieldType.Numeric.ToString("D"), typeof(NumericCustomField) },
                    { CustomFieldType.Date.ToString("D"), typeof(DateCustomField) },
                    { CustomFieldType.SingleList.ToString("D"), typeof(SingleListCustomField) },
                    { CustomFieldType.MultipleList.ToString("D"), typeof(MultipleListCustomField) },
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomField) },
                    { CustomFieldType.Radio.ToString("D"), typeof(RadioCustomField) },
                })
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set;}

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty("fieldTypeId")]
        public abstract CustomFieldType FieldType { get; }
    }
}
