using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class ProjectUserAddedActivityImpl : ActivityJsonImpl<ProjectUserAddedContentImpl>, ProjectUserAddedActivity
    {
        public override ActivityType Type => ActivityType.ProjectUserAdded;

        ProjectUserAddedContent ProjectUserAddedActivity.Content => this.Content;
    }

    public class ProjectUserAddedContentImpl : ProjectUserAddedContent
    {
        [JsonProperty(ItemConverterType = typeof(UserJsonImpl.JsonConverter))]
        public IList<User> Users { get; private set; }

        [JsonProperty]
        public string Comment { get; private set; }

        [JsonProperty(ItemConverterType = typeof(GroupProjectActivityJsonImpl.JsonConverter))]
        public IList<GroupProjectActivity> GroupProjectActivities { get; private set; }
    }
}
