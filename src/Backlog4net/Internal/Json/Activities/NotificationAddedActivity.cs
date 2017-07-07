using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Internal.Json.Activities
{
    public class NotificationAddedActivity : ActivityJsonImpl<NotificationAddedContent>
    {
        public override ActivityType Type => ActivityType.NotifyAdded;
    }

    public class NotificationAddedContent : IssueCommentedContent
    {
    }
}
