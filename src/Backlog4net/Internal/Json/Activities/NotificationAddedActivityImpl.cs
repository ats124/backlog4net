using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Internal.Json.Activities
{
    public class NotificationAddedActivityImpl : ActivityJsonImpl<NotificationAddedContentImpl>, NotificationAddedActivity
    {
        public override ActivityType Type => ActivityType.NotifyAdded;

        NotificationAddedContent NotificationAddedActivity.Content => this.Content;
    }

    public class NotificationAddedContentImpl : IssueCommentedContentImpl, NotificationAddedContent
    {
    }
}
