using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class GitRepositoryCreatedActivity : ActivityJsonImpl<GitRepositoryCreatedContent>
    {
        public override ActivityType Type => ActivityType.GitRepositoryCreated;
    }

    public class GitRepositoryCreatedContent: Content
    {
        [JsonProperty, JsonConverter(typeof(RepositoryJsonImpl.JsonConverter))]
        public Repository Repository { get; private set; }
    }
}
