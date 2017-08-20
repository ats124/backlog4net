using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Backlog4net.Test.TestConfig
{

    public class GeneralConfig
    {
        [JsonProperty]
        public string ApiKey { get; private set; }
        [JsonProperty]
        public string SpaceKey { get; private set; }
        [JsonProperty]
        public string ProjectKey { get; private set; }
        [JsonProperty]
        public string OwnUserId { get; private set; }

        public static Lazy<GeneralConfig> Instance { get; } = new Lazy<GeneralConfig>(() => JsonConvert.DeserializeObject<GeneralConfig>(File.ReadAllText(@"TestConfig\general.json")));
    }
}
