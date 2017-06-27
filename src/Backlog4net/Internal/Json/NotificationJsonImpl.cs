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

        [JsonProperty]
        public bool IsAlreadyRead { get; private set; }

        [JsonProperty]
        public Reason Reason { get; private set; }

        [JsonProperty]
        public bool ResouceAlreadyRead { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User Sender { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
		public User User { get; private set; }

        [JsonProperty, JsonConverter(typeof(ProjectJsonImpl.JsonConverter))]
        public Project Project { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueJsonImpl.JsonConverter))]

	}
}
