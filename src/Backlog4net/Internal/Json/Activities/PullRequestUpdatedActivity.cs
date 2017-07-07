using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class PullRequestUpdatedActivity : ActivityJsonImpl<PullRequestContent>
    {
        public override ActivityType Type => ActivityType.PullRequestUpdated;
    }
}
