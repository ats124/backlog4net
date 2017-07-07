using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class WikiTagJsonImpl : WikiTag
    {
        internal class JsonConverter : InterfaceConverter<WikiTag, WikiTagJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }
    }
}
