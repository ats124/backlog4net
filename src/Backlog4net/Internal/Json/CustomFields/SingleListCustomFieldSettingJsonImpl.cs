using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class SingleListCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, SingleListCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.SingleList;

        [JsonProperty(ItemConverterType = typeof(ListItemSettingJsonImpl.JsonConverter))]
        public IList<ListItemSetting> Items { get; private set; }

        [JsonProperty("allowAddItem")]
        public bool IsAllowAddItem { get; private set; }
    }
}
