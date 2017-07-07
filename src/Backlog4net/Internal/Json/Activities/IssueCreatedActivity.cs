using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueCreatedActivity : ActivityJsonImpl<IssueCreatedContent>
    {
        public override ActivityType Type => ActivityType.IssueCreated;
    }

    public class IssueCreatedContent : Content
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty("key_id")]
        public long KeyId { get; private set; }

        [JsonProperty]
        public string Summary { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public List<Attachment> Attachments { get; private set; }

        [JsonProperty("shared_files", ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public List<SharedFile> SharedFiles { get; private set; }
    }
}
