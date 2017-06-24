﻿using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json.CustomFields
{
    public abstract class CustomFieldJsonImpl : CustomField
    {
        [JsonProperty]
        public long Id {get; private set;}

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public int FieldTypeId { get; private set; }

        [JsonProperty]
        public FieldType Type => throw new NotImplementedException();
    }
}
