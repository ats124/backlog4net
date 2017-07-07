using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class CheckBoxCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.CheckBox;

        [JsonProperty]
        public List<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowInput { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
