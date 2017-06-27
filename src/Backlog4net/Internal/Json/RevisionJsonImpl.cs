using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class RevisionJsonImpl : Revision
    {
        internal class JsonConverter : InterfaceConverter<Revision, RevisionJsonImpl> { }

        [JsonProperty]
        public string Rev { get; private set; }

        [JsonProperty]
        public string Comment { get; private set; }
    }
}
