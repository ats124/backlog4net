using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class MultipleListCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.MultipleList;

        [JsonProperty]
        public List<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
