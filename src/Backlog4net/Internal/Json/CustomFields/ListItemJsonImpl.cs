using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class ListItemJsonImpl : ListItem
    {
        internal class JsonConverter : InterfaceConverter<ListItem, ListItemJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public int DisplayOrder { get; private set; }
    }
}
