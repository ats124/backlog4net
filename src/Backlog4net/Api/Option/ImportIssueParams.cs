using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class ImportIssueParams : CreateIssueParams
    {
        public ImportIssueParams(object projectId, string summary, object issueTypeId, IssuePriorityType priority)
            : base(projectId, summary, issueTypeId, priority)
        {
        }

        public long CreatedUserId { set => AddNewParamValue(value); }

        public string Created { set => AddNewParamValue(value); }

        public long UpdatedUserId { set => AddNewParamValue(value); }

        public string Updated { set => AddNewParamValue(value); }
    }
}
