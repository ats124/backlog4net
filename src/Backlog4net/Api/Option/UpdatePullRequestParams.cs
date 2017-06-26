using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdatePullRequestParams : PatchParams
    {
        private object projectIdOrKey;
        private object repoIdOrName;
        private object number;

        public UpdatePullRequestParams(object projectIdOrKey, object repoIdOrName, object number)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.repoIdOrName = repoIdOrName;
            this.number = number;
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string RepoIdOrName => repoIdOrName.ToString();

        public string Number => number.ToString();

        public string Summary { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public string Base { set => AddNewParamValue(value); }

        public string Branch { set => AddNewParamValue(value); }

        public long IssueId { set => AddNewParamValue(value); }

        public long AssigneeId { set => AddNewParamValue(value); }

        public IList<object> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        public IList<object> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }
    }
}
