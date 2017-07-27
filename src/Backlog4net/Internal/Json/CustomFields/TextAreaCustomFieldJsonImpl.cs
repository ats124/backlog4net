using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class TextAreaCustomFieldJsonImpl : CustomFieldJsonImpl, TextAreaCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.TextArea;

        [JsonProperty]
        public string Value { get; private set; }
    }
}
