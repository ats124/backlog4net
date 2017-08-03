using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class WikiTagJsonImpl : WikiTag
    {
        internal class JsonConverter : InterfaceConverter<WikiTag, WikiTagJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }
    }
}
