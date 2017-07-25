using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueMultiUpdatedActivityImpl : ActivityJsonImpl<IssueMultiUpdatedContentImpl>, IssueMultiUpdatedActivity
    {
        public override ActivityType Type => ActivityType.IssueMultiUpdated;

        IssueMultiUpdatedContent IssueMultiUpdatedActivity.Content => this.Content;
    }

    public class IssueMultiUpdatedContentImpl : IssueMultiUpdatedContent
    {
        [JsonProperty("tx_id")]
        public long TxId { get; private set; }

        [JsonProperty, JsonConverter(typeof(CommentJsonImpl.JsonConverter))]
        public Comment Comment { get; private set; }

        [JsonProperty(ItemConverterType = typeof(LinkJsonImpl.JsonConverter))]
        public IList<Link> Link { get; private set; }

        [JsonProperty(ItemConverterType = typeof(ChangeJsonImpl.JsonConverter))]
        public IList<Change> Changes { get; private set; }
    }
}
