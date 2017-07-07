using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class PullRequestAddedActivity : ActivityJsonImpl<PullRequestContent>
    {
        public override ActivityType Type => ActivityType.PullRequestAdded;
    }

    public class PullRequestContent : Content
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public long Number { get; private set; }

        [JsonProperty]
        public string Summary { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty, JsonConverter(typeof(CommentJsonImpl.JsonConverter))]
        public Comment Comment { get; private set; }

        [JsonProperty(ItemConverterType = typeof(ChangeJsonImpl.JsonConverter))]
        public List<Change> Changes { get; private set; }

        [JsonProperty, JsonConverter(typeof(RepositoryJsonImpl.JsonConverter))]
        public Repository Repository { get; private set; }
    }
}
