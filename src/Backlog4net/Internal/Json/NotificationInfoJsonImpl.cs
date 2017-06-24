using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class NotificationInfoJsonImpl : NotificationInfo
    {
        internal class JsonConverter : InterfaceConverter<NotificationInfo, NotificationInfoJsonImpl> { }

        [JsonProperty]
        public string Type { get; private set; }
    }
}
