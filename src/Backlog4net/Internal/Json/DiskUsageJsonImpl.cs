using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class DiskUsageJsonImpl : DiskUsage
    {
        internal class JsonConverter : InterfaceConverter<DiskUsage, DiskUsageJsonImpl> { }

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

        [JsonProperty(ItemConverterType = typeof(DiskUsageDetailJsonImpl.JsonConverter))]
        public DiskUsageDetail[] Details { get; private set; }
    }
}
