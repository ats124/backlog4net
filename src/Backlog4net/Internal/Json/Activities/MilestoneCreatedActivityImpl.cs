using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class MilestoneCreatedActivityImpl : ActivityJsonImpl<MilestoneCreatedContentImpl>, MilestoneCreatedActivity
    {
        public override ActivityType Type => ActivityType.MilestoneCreated;

        MilestoneCreatedContent MilestoneCreatedActivity.Content => this.Content;
    }

    public class MilestoneCreatedContentImpl : MilestoneCreatedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }

        [JsonProperty("reference_date")]
        public DateTime? ReferenceDate { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }
    }
}
