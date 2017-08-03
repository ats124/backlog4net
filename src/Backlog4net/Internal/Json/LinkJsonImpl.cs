using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class LinkJsonImpl : Link
    {
        internal class JsonConverter : InterfaceConverter<Link, LinkJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty("key_id")]
        public long KeyId { get; private set; }

        [JsonProperty]
        public string Title { get; private set; }
    }
}
