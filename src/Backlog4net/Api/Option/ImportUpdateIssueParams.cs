using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class ImportUpdateIssueParams : UpdateIssueParams
    {
        public ImportUpdateIssueParams(long issueId) : base(issueId) { }

        public ImportUpdateIssueParams(string issueKey) : base(issueKey) { }

        public long CreatedUserId { set => AddNewParamValue(value); }

        public string Created { set => AddNewParamValue(value); }

        public long UpdatedUserId { set => AddNewParamValue(value); }

        public string Updated { set => AddNewParamValue(value); }
    }
}
