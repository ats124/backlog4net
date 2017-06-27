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
        public DateTime Created { get; private set; }
    }

    public abstract class ActivityJsonImpl<T> : ActivityJsonImplBase where T : Content
    {
        [JsonProperty]
        public T Content { get; private set; }

        protected override Content InternalContent => this.Content;
    }
}
