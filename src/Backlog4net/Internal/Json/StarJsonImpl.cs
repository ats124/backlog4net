using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class StarJsonImpl : Star
    {
        internal class JsonConverter : InterfaceConverter<Star,StarJsonImpl>{}

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty]
        public string Url { get; private set; }

        [JsonProperty]
        public string Title { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User Presenter { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }
    }
}
