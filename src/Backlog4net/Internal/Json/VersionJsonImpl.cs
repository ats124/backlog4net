using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class VersionJsonImpl : Version
    {
        internal class JsonConverter : InterfaceConverter<Version, VersionJsonImpl> { };

        [JsonProperty]
        public long Id { get;  private set;}

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonIgnore]
        public string ProjectIdAsString => ProjectId.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public DateTime StartDate { get; private set; }

        [JsonProperty]
        public DateTime ReleaseDueDate { get; private set; }

        [JsonProperty]
        public bool Archived { get; private set; }

    }
}
