using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class MultipleListCustomFieldJsonImpl : CustomFieldJsonImpl, MultipleListCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.MultipleList;

        [JsonProperty(ItemConverterType = typeof(ListItemJsonImpl.JsonConverter))]
        public IList<ListItem> Value { get; private set; }
    }
}
