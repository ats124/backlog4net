using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdatePullRequestParams : PatchParams
    {
        public UpdatePullRequestParams(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.RepoIdOrName = repoIdOrName;
            this.Number = number;
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public IdOrKey RepoIdOrName { get; private set; }

        public long Number { get; private set; }

        public string Summary { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public long IssueId { set => AddNewParamValue(value); }

        public long AssigneeId { set => AddNewParamValue(value); }

        public IList<long> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }
    }
}
