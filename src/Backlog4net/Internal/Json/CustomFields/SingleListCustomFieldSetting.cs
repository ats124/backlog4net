using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class SingleListCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.SingleList;

        [JsonProperty]
        public List<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
