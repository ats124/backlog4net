using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public abstract class ActivityJsonImplBase : Activity
    {
        internal class JsonConverter : MultiTypeConverter<Activity>
        {
            public JsonConverter() :
                base("type", new Dictionary<string, Type>
                {
                    { ActivityType.FileAdded.ToString("D"), typeof(FileAddedActivityImpl) },
                    { ActivityType.FileDeleted.ToString("D"), typeof(FileDeletedActivityImpl) },
                    { ActivityType.FileUpdated.ToString("D"), typeof(FileUpdatedActivityImpl) },
                    { ActivityType.GitPushed.ToString("D"), typeof(GitPushedActivityImpl) },
                    { ActivityType.GitRepositoryCreated.ToString("D"), typeof(GitRepositoryCreatedActivityImpl) },
                    { ActivityType.IssueCommented.ToString("D"), typeof(IssueCommentedActivityImpl) },
                    { ActivityType.IssueCreated.ToString("D"), typeof(IssueCreatedActivityImpl) },
                    { ActivityType.IssueDeleted.ToString("D"), typeof(IssueDeletedActivityImpl) },
                    { ActivityType.IssueMultiUpdated.ToString("D"), typeof(IssueMultiUpdatedActivityImpl) },
                    { ActivityType.IssueUpdated.ToString("D"), typeof(IssueUpdatedActivityImpl) },
                    { ActivityType.NotifyAdded.ToString("D"), typeof(NotificationAddedActivityImpl) },
                    { ActivityType.ProjectUserAdded.ToString("D"), typeof(ProjectUserAddedActivityImpl) },
                    { ActivityType.ProjectUserRemoved.ToString("D"), typeof(ProjectUserRemovedActivityImpl) },
                    { ActivityType.PullRequestAdded.ToString("D"), typeof(PullRequestAddedActivityImpl) },
                    { ActivityType.PullRequestCommented.ToString("D"), typeof(PullRequestCommentedActivityImpl) },
                    { ActivityType.PullRequestUpdated.ToString("D"), typeof(PullRequestUpdatedActivityImpl) },
                    { ActivityType.SvnCommitted.ToString("D"), typeof(SvnCommittedActivityImpl) },
                    { ActivityType.WikiCreated.ToString("D"), typeof(WikiCreatedActivityImpl) },
                    { ActivityType.WikiDeleted.ToString("D"), typeof(WikiDeletedActivityImpl) },
                    { ActivityType.WikiUpdated.ToString("D"), typeof(WikiUpdatedActivityImpl) },
                }, typeof(UndefinedActivityImpl))
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        Content Activity.Content => this.InternalContent;

        [JsonIgnore]
        protected abstract Content InternalContent { get; }

        [JsonProperty, JsonConverter(typeof(ProjectJsonImpl.JsonConverter))]
        public Project Project { get; private set; }

        [JsonProperty("type")]
        public abstract ActivityType Type { get; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }
    }

    public abstract class ActivityJsonImpl<T> : ActivityJsonImplBase where T : Content
    {
        [JsonProperty]
        public T Content { get; private set; }

        protected override Content InternalContent => this.Content;
    }
}
