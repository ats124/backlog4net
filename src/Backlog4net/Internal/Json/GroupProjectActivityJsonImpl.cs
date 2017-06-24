using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class GroupProjectActivityJsonImpl : GroupProjectActivity
    {
        internal class JsonConverter : InterfaceConverter<GroupProjectActivity, GroupProjectActivityJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public ActivityType Type { get; private set; }
    }
}
