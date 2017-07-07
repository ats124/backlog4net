using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class SingleListCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.SingleList;

        [JsonProperty]
        public ListItem Value { get; private set; }
    }
}
