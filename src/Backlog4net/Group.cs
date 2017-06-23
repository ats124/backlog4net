using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog group data.
    /// </summary>
    public sealed class Group
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public User[] Members { get; private set; }

        [JsonProperty]
        public long DisplayOrder { get; private set; }

        [JsonProperty]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }

        [JsonProperty]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime Updated { get; private set; }
    }
}
