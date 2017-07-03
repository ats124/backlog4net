using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class NotificationJsonImpl : Notification
    {
        internal class JsonConverter : InterfaceConverter<Notification, NotificationJsonImpl> { };

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty("alreadyRead")]
        public bool IsAlreadyRead { get; private set; }

        [JsonProperty]
        public Reason Reason { get; private set; }

        [JsonProperty("resourceAlreadyRead")]
        public bool IsResourceAlreadyRead { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User Sender { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
		public User User { get; private set; }

        [JsonProperty, JsonConverter(typeof(ProjectJsonImpl.JsonConverter))]
        public Project Project { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueJsonImpl.JsonConverter))]
        public Issue Issue { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueCommentJsonImpl.JsonConverter))]
        public IssueComment Comment { get; private set; }

        [JsonProperty, JsonConverter(typeof(PullRequestJsonImpl.JsonConverter))]
        public PullRequest PullRequest { get; private set; }

        [JsonProperty, JsonConverter(typeof(PullRequestCommentJsonImpl.JsonConverter))]
        public PullRequestComment PullRequestComment { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }
    }
}
