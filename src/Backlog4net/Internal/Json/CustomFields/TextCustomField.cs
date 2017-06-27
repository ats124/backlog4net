using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class TextCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.Text;

        [JsonProperty]
        public string Value { get; private set; }
    }
}
