using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class GitPushedActivity : ActivityJsonImpl<GitPushedContent>
    {
        public override ActivityType Type => ActivityType.GitPushed;
    }

    public class GitPushedContent : Content
    {
        [JsonProperty("change_type")]
        public string ChangeType { get; private set; }

        [JsonProperty]
        public string Ref { get; private set; }

        [JsonProperty("revision_type")]
        public string RevisionType { get; private set; }

        [JsonProperty, JsonConverter(typeof(RepositoryJsonImpl.JsonConverter))]
        public Repository Repository { get; private set; }

        [JsonProperty(ItemConverterType = typeof(RevisionJsonImpl.JsonConverter))]
        public Revision[] Revisions { get; private set; }

        [JsonProperty("revision_count")]
        public long RevisionCount { get; private set; }

    }
}
