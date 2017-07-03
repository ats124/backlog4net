using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class SpaceNotificationJsonImpl : SpaceNotification
    {
        internal class JsonConverter : InterfaceConverter<SpaceNotification, SpaceNotificationJsonImpl> { }

        [JsonProperty]
        public string Content { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }
    }
}
