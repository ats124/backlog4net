using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class ImportIssueParams : CreateIssueParams
    {
        public ImportIssueParams(IdOrKey projectId, string summary, long issueTypeId, IssuePriorityType priority)
            : base(projectId, summary, issueTypeId, priority)
        {
        }

        public long CreatedUserId { set => AddNewParamValue(value); }

        public DateTime Created { set => AddNewParamValue(ToDateTimeString(value)); }

        public long UpdatedUserId { set => AddNewParamValue(value); }

        public DateTime Updated { set => AddNewParamValue(ToDateTimeString(value)); }
    }
}
