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
                    { CustomFieldType.Text.ToString("D"), typeof(TextCustomFieldJsonImpl) },
                    { CustomFieldType.TextArea.ToString("D"), typeof(TextAreaCustomFieldJsonImpl) },
                    { CustomFieldType.Numeric.ToString("D"), typeof(NumericCustomFieldJsonImpl) },
                    { CustomFieldType.Date.ToString("D"), typeof(DateCustomFieldJsonImpl) },
                    { CustomFieldType.SingleList.ToString("D"), typeof(SingleListCustomFieldJsonImpl) },
                    { CustomFieldType.MultipleList.ToString("D"), typeof(MultipleListCustomFieldJsonImpl) },
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomFieldJsonImpl) },
                    { CustomFieldType.Radio.ToString("D"), typeof(RadioCustomFieldJsonImpl) },
                })
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set;}

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty("fieldTypeId")]
        public abstract CustomFieldType FieldType { get; }
    }
}
