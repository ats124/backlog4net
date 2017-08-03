using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class WikiHistoryJsonImpl :WikiHistory
    {
        internal class JsonConverter : InterfaceConverter<WikiHistory, WikiHistoryJsonImpl> { };

        [JsonProperty]
        public long PageId { get; private set; }

        [JsonProperty]
        public int Version { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Content { get; private set; }

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
