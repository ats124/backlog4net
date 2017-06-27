using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class ProjectUserRemovedActivity : ActivityJsonImpl<ProjectUserRemovedContent>
    {
        public override ActivityType Type => ActivityType.ProjectUserRemoved;
    }

    public class ProjectUserRemovedContent : Content
    {
        [JsonProperty(ItemConverterType = typeof(UserJsonImpl.JsonConverter))]
        public User[] Users { get; private set; }

        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty(ItemConverterType = typeof(GroupProjectActivityJsonImpl.JsonConverter))]
        public GroupProjectActivity[] GroupProjectActivities { get; private set; }
    }
}
