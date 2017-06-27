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

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty("key_id")]
        public long KeyId { get; private set; }

        [JsonIgnore]
        public string KeyIdAsString => KeyId.ToString();

        [JsonProperty]
        public string Title { get; private set; }
    }
}
