using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class ListItemSettingJsonImpl : ListItemSetting
    {
        internal class JsonConverter : InterfaceConverter<ListItemSetting, ListItemSettingJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public bool AllowInput { get; private set; }

        [JsonProperty]
        public int DisplayOrder { get; private set; }
    }
}
