using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class SvnCommittedActivity : ActivityJsonImpl<SvnCommittedContent>
    {
        public override ActivityType Type => ActivityType.SvnCommitted;
    }

    public class SvnCommittedContent : Content
    {
        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty]
        public long Rev { get; private set; }
    }
}
