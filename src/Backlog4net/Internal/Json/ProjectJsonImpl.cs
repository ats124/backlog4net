using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class ProjectJsonImpl : Project
    {
        internal class JsonConverter : InterfaceConverter<Project, ProjectJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string ProjectKey { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty("chartEnabled")]
        public bool IsChartEnabled { get; private set; }

        [JsonProperty("subtaskingEnabled")]
        public bool IsSubtaskingEnabled { get; private set; }

        [JsonProperty]
        public TextFormattingRule TextFormattingRule { get; private set; }

        [JsonProperty("archived")]
        public bool IsArchived { get; private set; }

        [JsonProperty]
        public long DisplayOrder { get; private set; }
    }
}
