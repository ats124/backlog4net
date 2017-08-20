using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Backlog4net.Test.TestConfig
{
    public class GitConfig
    {
        public static Lazy<GitConfig> Instance { get; } = new Lazy<GitConfig>(() => JsonConvert.DeserializeObject<GitConfig>(File.ReadAllText(@"TestConfig\git.json")));

        [JsonProperty]
        public string RepoName { get; private set; }

        [JsonProperty]
        public string Base { get; private set; }

        [JsonProperty]
        public string Branch { get; private set; }

        [JsonProperty]
        public string NotifiedUserId1 { get; private set; }

        [JsonProperty]
        public string NotifiedUserId2 { get; private set; }

        [JsonProperty]
        public string NotifiedUserId3 { get; private set; }

        [JsonProperty]
        public string AssigneeUserId1 { get; private set; }

        [JsonProperty]
        public string AssigneeUserId2 { get; private set; }

        [JsonProperty]
        public string AssigneeUserId3 { get; private set; }
    }
}
