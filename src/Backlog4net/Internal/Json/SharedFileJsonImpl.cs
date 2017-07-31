using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class SharedFileJsonImpl : SharedFile
    {
        internal class JsonConverter : InterfaceConverter<SharedFile, SharedFileJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public bool IsImage => Extensions.IsImageName(Name);

        [JsonProperty]
        public string Dir { get; private set; }

        [JsonProperty]
        public long Size { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }
    }
}
