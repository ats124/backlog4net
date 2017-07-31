using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class ResolutionJsonImpl :Resolution
    {
        internal class JsonConverter : InterfaceConverter<Resolution, ResolutionJsonImpl> { };

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public IssueResolutionType ResolutionType => (IssueResolutionType)Id;


    }
}
