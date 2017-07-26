using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class TextCustomFieldJsonImpl : CustomFieldJsonImpl, TextCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.Text;

        [JsonProperty]
        public string Value { get; private set; }
    }
}
