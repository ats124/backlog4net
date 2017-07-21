using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class PullRequestUpdatedActivityImpl : ActivityJsonImpl<PullRequestContentImpl>, PullRequestUpdatedActivity
    {
        public override ActivityType Type => ActivityType.PullRequestUpdated;

        PullRequestContent PullRequestUpdatedActivity.Content => this.Content;
    }
}
