using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueTypeParams : PatchParams
    {
        private object projectIdOrKey;
        private object issueTypeId;

        public UpdateIssueTypeParams(object projectIdOrKey, object issueTypeId)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.issueTypeId = issueTypeId;
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string IssueTypeId => issueTypeId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public string Color { set => AddNewParamValue(value); }
    }
}
