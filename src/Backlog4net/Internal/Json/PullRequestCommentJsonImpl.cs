using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class PullRequestCommentJsonImpl : PullRequestComment
    {
        internal class JsonConverter : InterfaceConverter<PullRequestComment, PullRequestCommentJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Content { get; private set; }
        
        [JsonProperty(ItemConverterType = typeof(ChangeLogJsonImpl.JsonConverter))]
        public ChangeLog[] ChangeLog { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }

        [JsonProperty(ItemConverterType = typeof(StarJsonImpl.JsonConverter))]
        public Star[] Stars { get; private set; }

        [JsonProperty(ItemConverterType = typeof(NotificationInfoJsonImpl.JsonConverter))]
        public Notification[] Notifications { get; private set; }
    }
}
