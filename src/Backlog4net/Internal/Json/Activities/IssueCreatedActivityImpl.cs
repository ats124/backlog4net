using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class IssueCreatedActivityImpl : ActivityJsonImpl<IssueCreatedContentImpl>, IssueCreatedActivity
    {
        public override ActivityType Type => ActivityType.IssueCreated;

        IssueCreatedContent IssueCreatedActivity.Content => this.Content;
    }

    public class IssueCreatedContentImpl : IssueCreatedContent
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
        public IList<Attachment> Attachments { get; private set; }

        [JsonProperty("shared_files", ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public IList<SharedFile> SharedFiles { get; private set; }
    }
}
