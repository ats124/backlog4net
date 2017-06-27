using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class RadioCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.Radio;

        [JsonProperty]
        public ListItem Value { get; private set; }

        [JsonProperty]
        public string OtherValue { get; private set; }
    }
}
