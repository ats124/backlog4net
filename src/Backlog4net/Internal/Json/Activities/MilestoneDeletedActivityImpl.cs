using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class MilestoneDeletedActivityImpl : ActivityJsonImpl<MilestoneDeletedContentImpl>, MilestoneDeletedActivity
    {
        public override ActivityType Type => ActivityType.MilestoneDeleted;

        MilestoneDeletedContent MilestoneDeletedActivity.Content => this.Content;
    }

    public class MilestoneDeletedContentImpl : MilestoneDeletedContent
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
