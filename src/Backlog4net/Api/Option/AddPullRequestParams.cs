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
        private object projectIdOrKey;
        private object repoIdOrName;

        public AddPullRequestParams(object projectIdOrKey, object repoIdOrName, string summary, string description, string @base, string branch)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.repoIdOrName = repoIdOrName;
            AddNewParam("summary", summary);
            AddNewParam("description", description);
            AddNewParam("base", @base);
            AddNewParam("branch", branch);
        }

        /// <summary>
        /// Returns the project identifier string.
        /// </summary>
        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string RepoIdOrName => repoIdOrName.ToString();

        public object IssueId { set => AddNewParamValue(value); }

        public object AssigneeId { set => AddNewParamValue(value); }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<object> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<object> AttachmentIds { set => AddNewArrayParams("attachmentId[]", value); }
    }
}
