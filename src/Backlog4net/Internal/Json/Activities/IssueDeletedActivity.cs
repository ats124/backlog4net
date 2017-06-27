using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueDeletedActivity : ActivityJsonImpl<IssueDeletedContent>
    {
        public override ActivityType Type => ActivityType.IssueDeleted;
    }

    public class IssueDeletedContent : Content
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty("key_id")]
        public long KeyId { get; private set; }
    }
}
