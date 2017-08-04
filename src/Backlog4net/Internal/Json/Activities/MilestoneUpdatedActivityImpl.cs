using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class MilestoneUpdatedActivityImpl : ActivityJsonImpl<MilestoneUpdatedContentImpl>, MilestoneUpdatedActivity
    {
        public override ActivityType Type => ActivityType.MilestoneUpdated;

        MilestoneUpdatedContent MilestoneUpdatedActivity.Content => this.Content;
    }

    public class MilestoneUpdatedContentImpl : MilestoneUpdatedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty(ItemConverterType = typeof(ChangeJsonImpl.JsonConverter))]
        public IList<Change> Changes { get; private set; }
    }
}
