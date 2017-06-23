using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    public sealed class AttributeInfo
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Type { get; private set; }
    }
}
