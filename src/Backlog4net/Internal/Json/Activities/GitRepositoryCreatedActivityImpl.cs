using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class GitRepositoryCreatedActivityImpl : ActivityJsonImpl<GitRepositoryCreatedContentImpl>, GitRepositoryCreatedActivity
    {
        public override ActivityType Type => ActivityType.GitRepositoryCreated;

        GitRepositoryCreatedContent GitRepositoryCreatedActivity.Content => this.Content;
    }

    public class GitRepositoryCreatedContentImpl: GitRepositoryCreatedContent
    {
        [JsonProperty, JsonConverter(typeof(RepositoryJsonImpl.JsonConverter))]
        public Repository Repository { get; private set; }
    }
}
