using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class MultipleListCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, MultipleListCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.MultipleList;

        [JsonProperty(ItemConverterType = typeof(ListItemSettingJsonImpl.JsonConverter))]
        public IList<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
