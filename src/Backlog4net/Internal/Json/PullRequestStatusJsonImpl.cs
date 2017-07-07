using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class PullRequestStatusJsonImpl : PullRequestStatus
    {
        internal class JsonConverter : InterfaceConverter<PullRequestStatus, PullRequestStatusJsonImpl> { }

        [JsonProperty]
        public int Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public PullRequestStatusType Status => (PullRequestStatusType)Id;
    }
}
