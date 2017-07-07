using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class ChangeJsonImpl : Change
    {
        internal class JsonConverter : InterfaceConverter<Change, ChangeJsonImpl> { }

        [JsonProperty]
        public long Field { get; private set; }

        [JsonProperty("new_value")]
        public string NewValue { get; private set; }

        [JsonProperty("old_value")]
        public string OldValue { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }
    }
}
