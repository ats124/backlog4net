using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog change data.
    /// </summary>
    public sealed class Change
    {
        [JsonProperty]
        public long Field { get; private set; }

        [JsonProperty("new_value")]
        public string NewValue { get; private set; }

        [JsonProperty("old_value")]
        public string OldValue { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }
    }
}
