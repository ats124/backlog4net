using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class AttributeInfoJsonImpl : AttributeInfo
    {
        internal class JsonConverter : InterfaceConverter<AttributeInfo, AttributeInfoJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }
    }
}
