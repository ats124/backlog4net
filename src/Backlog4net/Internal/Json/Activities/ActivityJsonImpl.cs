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
                    { ActivityType.FileAdded.ToString("D"), typeof(FileAddedActivity) },
                    { ActivityType.FileDeleted.ToString("D"), typeof(FileDeletedActivity) },
                    { ActivityType.FileUpdated.ToString("D"), typeof(FileUpdatedActivity) },
                    { ActivityType.GitPushed.ToString("D"), typeof(GitPushedActivity) },
                    { ActivityType.GitRepositoryCreated.ToString("D"), typeof(GitRepositoryCreatedActivity) },
                    { ActivityType.IssueCommented.ToString("D"), typeof(IssueCommentedActivity) },
                    { ActivityType.IssueCreated.ToString("D"), typeof(IssueCreatedActivity) },
                    { ActivityType.IssueDeleted.ToString("D"), typeof(IssueDeletedActivity) },
                    { ActivityType.IssueMultiUpdated.ToString("D"), typeof(IssueMultiUpdatedActivity) },
                    { ActivityType.IssueUpdated.ToString("D"), typeof(IssueUpdatedActivity) },
                    { ActivityType.NotifyAdded.ToString("D"), typeof(NotificationAddedActivity) },
                    { ActivityType.ProjectUserAdded.ToString("D"), typeof(ProjectUserAddedActivity) },
                    { ActivityType.ProjectUserRemoved.ToString("D"), typeof(ProjectUserRemovedActivity) },
                    { ActivityType.PullRequestAdded.ToString("D"), typeof(PullRequestAddedActivity) },
                    { ActivityType.PullRequestCommented.ToString("D"), typeof(PullRequestCommentedActivity) },
                    { ActivityType.PullRequestUpdated.ToString("D"), typeof(PullRequestUpdatedActivity) },
                    { ActivityType.SvnCommitted.ToString("D"), typeof(SvnCommittedActivity) },
                    { ActivityType.WikiCreated.ToString("D"), typeof(WikiCreatedActivity) },
                    { ActivityType.WikiDeleted.ToString("D"), typeof(WikiDeletedActivity) },
                    { ActivityType.WikiUpdated.ToString("D"), typeof(WikiUpdatedActivity) },
                }, typeof(UndefinedActivity))
            {
            }
        }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

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
