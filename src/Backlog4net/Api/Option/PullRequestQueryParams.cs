using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class PullRequestQueryParams : QueryParams
    {
        public IList<PullRequestStatusType> StatusType { set => AddNewArrayParams("statusId[]", value, x => x.ToString("D")); }

        public IList<long> AssigneeIds { set => AddNewArrayParams("assigneeId[]", value); }

        public IList<long> IssueIds { set => AddNewArrayParams("issueId[]", value); }

        public IList<long> CreatedUserIds { set => AddNewArrayParams("createdUserId[]", value); }
    }
}
