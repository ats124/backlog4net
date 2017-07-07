using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class CheckBoxCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.CheckBox;

        [JsonProperty]
        public List<ListItem> Value { get; private set; }

        [JsonProperty]
        public string OtherValue { get; private set; }
    }
}
