using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add pull request comment API.
    /// </summary>
    public class AddPullRequestParams : PostParams
    {
        public AddPullRequestParams(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, string summary, string description, string @base, string branch)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.RepoIdOrName = repoIdOrName;
            AddNewParam("summary", summary);
            AddNewParam("description", description);
            AddNewParam("base", @base);
            AddNewParam("branch", branch);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public IdOrKey RepoIdOrName { get; private set; }

        public long IssueId { set => AddNewParamValue(value); }

        public long AssigneeId { set => AddNewParamValue(value); }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<long> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<long> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }
    }
}
