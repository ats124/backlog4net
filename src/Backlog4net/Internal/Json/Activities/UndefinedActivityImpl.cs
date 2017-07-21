using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Internal.Json.Activities
{
    public class UndefinedActivityImpl : ActivityJsonImpl<UndefinedContentImpl>, UndefinedActivity
    {
        public override ActivityType Type => ActivityType.Undefined;

        UndefinedContent UndefinedActivity.Content => this.Content;
    }

    public class UndefinedContentImpl : UndefinedContent
    {
    }
}
