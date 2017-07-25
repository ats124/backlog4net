using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class PullRequestCommentedActivityImpl : ActivityJsonImpl<PullRequestContentImpl>, PullRequestCommentedActivity
    {
        public override ActivityType Type => ActivityType.PullRequestCommented;

        PullRequestContent PullRequestCommentedActivity.Content => this.Content;
    }
}
