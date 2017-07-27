using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class CheckBoxCustomFieldJsonImpl : CustomFieldJsonImpl, CheckBoxCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.CheckBox;

        [JsonProperty(ItemConverterType = typeof(ListItemJsonImpl.JsonConverter))]
        public IList<ListItem> Value { get; private set; }

        [JsonProperty]
        public string OtherValue { get; private set; }
    }
}
