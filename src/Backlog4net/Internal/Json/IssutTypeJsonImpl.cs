using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class IssutTypeJsonImpl : IssueType
    {
        internal class JsonConverter : InterfaceConverter<IssueType, IssutTypeJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonIgnore]
        public string ProjectIdAsString => ProjectId.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Color { get; private set; }
    }
}
