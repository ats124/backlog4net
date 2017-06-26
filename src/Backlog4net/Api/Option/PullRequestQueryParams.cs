using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class PullRequestQueryParams : QueryParams
    {
        public IList<PullRequestStatusType> StatusType { set => AddNewArrayParams("statusId[]", value, x => x.ToString("D")); }

        public IList<object> AssigneeIds { set => AddNewArrayParams("assigneeId[]", value); }

        public IList<object> IssueIds { set => AddNewArrayParams("issueId[]", value); }

        public IList<object> CreatedUserIds { set => AddNewArrayParams("createdUserId[]", value); }
    }
}
