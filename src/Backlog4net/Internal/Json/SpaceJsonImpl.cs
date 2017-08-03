using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class SpaceJsonImp : Space
    {
        internal class JsonConverter : InterfaceConverter<Space, SpaceJsonImp> { }

        [JsonProperty]
        public string SpaceKey { get; private set; }
        
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public long OwnerId { get; private set; }

        [JsonProperty]
        public string Lang { get; private set; }

        [JsonProperty]
        public string Timezone { get; private set; }

        [JsonProperty]
        public string ReportSendTime { get; private set; }

        [JsonProperty]
        public string TextFormattingRule { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }
    }
}
