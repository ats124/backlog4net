using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class SvnCommittedActivityImpl : ActivityJsonImpl<SvnCommittedContentImpl>, SvnCommittedActivity
    {
        public override ActivityType Type => ActivityType.SvnCommitted;

        SvnCommittedContent SvnCommittedActivity.Content => this.Content;
    }

    public class SvnCommittedContentImpl : SvnCommittedContent
    {
        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty]
        public long Rev { get; private set; }
    }
}
