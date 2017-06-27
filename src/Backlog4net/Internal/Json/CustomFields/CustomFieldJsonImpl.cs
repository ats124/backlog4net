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
                    { CustomFieldType.CheckBox.ToString("D"), typeof(CheckBoxCustomField) }
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
