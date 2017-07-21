using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class GitPushedActivityImpl : ActivityJsonImpl<GitPushedContentImpl>, GitPushedActivity
    {
        public override ActivityType Type => ActivityType.GitPushed;

        GitPushedContent GitPushedActivity.Content => this.Content;
    }

    public class GitPushedContentImpl : GitPushedContent
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
        public IList<Revision> Revisions { get; private set; }

        [JsonProperty("revision_count")]
        public long RevisionCount { get; private set; }

    }
}
