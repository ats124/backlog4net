using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class PriorityJsonImpl : Priority
    {
        internal class JsonConverter : InterfaceConverter<Priority, PriorityJsonImpl> { };

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public IssuePriorityType PriorityType => (IssuePriorityType)Id;
    }
}
