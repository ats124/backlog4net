using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Internal.Json.Activities
{
    public class UndefinedActivity : ActivityJsonImpl<UndefinedContent>
    {
        public override ActivityType Type => ActivityType.Undefined;
    }

    public class UndefinedContent : Content
    {
    }
}
