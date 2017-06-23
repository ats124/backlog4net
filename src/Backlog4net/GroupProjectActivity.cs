using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog group project activity data.
    /// </summary>
    public sealed class GroupProjectActivity
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public ActivityType Type { get; private set; }
    }
}
