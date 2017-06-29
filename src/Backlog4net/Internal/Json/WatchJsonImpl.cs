using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class WatchJsonImpl : Watch
    {
        internal class JsonConverter : InterfaceConverter<Watch, WatchJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public bool AlreadyRead { get; private set; }

        [JsonIgnore]
        public string AlreadyReadAsString { get; private set; }

        [JsonProperty]
        public string Note { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueJsonImpl.JsonConverter))]
        public Issue Issue { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }

        [JsonProperty]
        public DateTime Updated { get; private set; }
    }
}
