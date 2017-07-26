using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class RadioCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, RadioCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.Radio;

        [JsonProperty(ItemConverterType = typeof(ListItemSettingJsonImpl.JsonConverter))]
        public IList<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowInput { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
