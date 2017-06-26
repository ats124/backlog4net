using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueTypeParams : PatchParams
    {
        private object issueIdOrKey;
        private object issueTypeId;

        public UpdateIssueTypeParams(object issueIdOrKey, object issueTypeId)
        {
            this.issueIdOrKey = issueIdOrKey;
            this.issueTypeId = issueTypeId;
        }

        public string IssueIdOrKeyString => issueIdOrKey.ToString();

        public string IssueTypeId => issueTypeId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public string Color { set => AddNewParamValue(value); }
    }
}
