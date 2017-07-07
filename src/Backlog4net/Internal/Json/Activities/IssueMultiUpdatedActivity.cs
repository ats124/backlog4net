using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueMultiUpdatedActivity : ActivityJsonImpl<IssueMultiUpdatedContent>
    {
        public override ActivityType Type => ActivityType.IssueMultiUpdated;
    }

    public class IssueMultiUpdatedContent : Content
    {
        [JsonProperty("tx_id")]
        public long TxId { get; private set; }

        [JsonProperty, JsonConverter(typeof(CommentJsonImpl.JsonConverter))]
        public Comment Comment { get; private set; }

        [JsonProperty(ItemConverterType = typeof(LinkJsonImpl.JsonConverter))]
        public List<Link> Link { get; private set; }

        [JsonProperty(ItemConverterType = typeof(ChangeJsonImpl.JsonConverter))]
        public List<Change> Changes { get; private set; }
    }
}
