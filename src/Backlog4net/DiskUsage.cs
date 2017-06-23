using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog disk usage data.
    /// </summary>
    public sealed class DiskUsage
    {
        [JsonProperty]
        public long Capacity { get; private set; }

        [JsonProperty]
        public long Issue { get; private set; }

        [JsonProperty]
        public long Wiki { get; private set; }

        [JsonProperty]
        public long File { get; private set; }

        [JsonProperty]
        public long Subversion { get; private set; }

        [JsonProperty]
        public long Git { get; private set; }

        [JsonProperty]
        public DiskUsageDetail[] Details { get; private set; }
    }
}
