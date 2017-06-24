using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class CountJsonImpl : Count
    {
        internal class JsonConverter : InterfaceConverter<Count, CountJsonImpl> { }

        [JsonProperty("count")]
        public int CountValue { get; private set; }
    }
}
