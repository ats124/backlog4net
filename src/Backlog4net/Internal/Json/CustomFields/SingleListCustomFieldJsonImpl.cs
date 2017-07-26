using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class SingleListCustomFieldJsonImpl : CustomFieldJsonImpl, SingleListCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.SingleList;

        [JsonProperty]
        [JsonConverter(typeof(ListItemJsonImpl.JsonConverter))]
        public ListItem Value { get; private set; }
    }
}
