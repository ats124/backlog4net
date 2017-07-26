using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class RadioCustomFieldJsonImpl : CustomFieldJsonImpl, RadioCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.Radio;

        [JsonProperty]
        [JsonConverter(typeof(ListItemJsonImpl.JsonConverter))]
        public ListItem Value { get; private set; }

        [JsonProperty]
        public string OtherValue { get; private set; }
    }
}
