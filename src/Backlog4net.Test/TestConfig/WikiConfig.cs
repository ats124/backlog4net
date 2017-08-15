using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Backlog4net.Test.TestConfig
{

    public class WikiConfig
    {
        public static Lazy<WikiConfig> Instance { get; } = new Lazy<WikiConfig>(() => JsonConvert.DeserializeObject<WikiConfig>(File.ReadAllText(@"TestConfig\wiki.json")));

        [JsonProperty]
        public string SharedFileDirectory { get; private set; }

        [JsonProperty]
        public string SharedFile1 { get; private set; }

        [JsonProperty]
        public DateTime SharedFile1Created { get; private set; }

        [JsonProperty]
        public string SharedImageFile1 { get; private set; }
    }

}
