using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueTypeParams : PatchParams
    {
        public UpdateIssueTypeParams(IdOrKey projectIdOrKey, long issueTypeId)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.IssueTypeId = issueTypeId;
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public long IssueTypeId { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public string Color { set => AddNewParamValue(value); }
    }
}
