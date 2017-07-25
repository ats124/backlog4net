using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueDeletedActivityImpl : ActivityJsonImpl<IssueDeletedContentImpl>, IssueDeletedActivity
    {
        public override ActivityType Type => ActivityType.IssueDeleted;

        IssueDeletedContent IssueDeletedActivity.Content => this.Content;
    }

    public class IssueDeletedContentImpl : IssueDeletedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty("key_id")]
        public long KeyId { get; private set; }
    }
}
