using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class WikiUpdatedActivity : ActivityJsonImpl<WikiUpdatedContent>
    {
        public override ActivityType Type => ActivityType.WikiUpdated;
    }

    public class WikiUpdatedContent : Content
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty]
        public string Content { get; private set; }

        [JsonProperty]
        public string Diff { get; private set; }

        [JsonProperty]
        public int Version { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public List<Attachment> Attachments { get; private set; }

        [JsonProperty("shared_files", ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public List<SharedFile> SharedFiles { get; private set; }
    }
}
