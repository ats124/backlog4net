using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class MultipleListCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.MultipleList;

        [JsonProperty]
        public List<ListItem> Value { get; private set; }
    }
}
