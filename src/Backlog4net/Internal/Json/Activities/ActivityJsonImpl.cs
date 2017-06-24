using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public abstract class ActivityJsonImpl : Activity
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty, JsonConverter(typeof(ProjectJsonImpl.JsonConverter))]
        public Project Project { get; private set; }

        [JsonProperty]
        public ActivityType Type { get; private set; }

        [JsonProperty]
        public Content Content { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }
    }
}
