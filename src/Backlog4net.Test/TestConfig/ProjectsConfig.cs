using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Backlog4net.Test.TestConfig
{

    public class ProjectsConfig
    {
        public static Lazy<ProjectsConfig> Instance { get; } = new Lazy<ProjectsConfig>(() => JsonConvert.DeserializeObject<ProjectsConfig>(File.ReadAllText(@"TestConfig\projects.json")));

        [JsonProperty]
        public string AnotherUserId { get; private set; }
    }

}
