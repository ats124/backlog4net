using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    public sealed class NotificationInfo
    {
        [JsonProperty]
        public string Type { get; private set; }
    }
}
