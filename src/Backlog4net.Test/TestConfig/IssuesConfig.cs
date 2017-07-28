using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Backlog4net.Test.TestConfig
{

    public class IssuesConfig
    {
        public static Lazy<IssuesConfig> Instance { get; } = new Lazy<IssuesConfig>(() => JsonConvert.DeserializeObject<IssuesConfig>(File.ReadAllText(@"TestConfig\issues.json")));

        [JsonProperty]
        public string NotifiedUserId1 { get; private set; }

        [JsonProperty]
        public string NotifiedUserId2 { get; private set; }

        [JsonProperty]
        public string NotifiedUserId3 { get; private set; }

    }

}
