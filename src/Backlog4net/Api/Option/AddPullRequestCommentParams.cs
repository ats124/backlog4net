using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add pull request comment API.
    /// </summary>
    public class AddPullRequestCommentParams : PostParams
    {
        private object projectIdOrKey;
        private object repoIdOrName;
        private object number;

        public AddPullRequestCommentParams(object projectIdOrKey, object repoIdOrName, object number, string content)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.repoIdOrName = repoIdOrName;
            this.number = number;
            AddNewParam("content", content);
        }

        /// <summary>
        /// Returns the project identifier string.
        /// </summary>
        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string RepoIdOrName => repoIdOrName.ToString();

        public string Number => number.ToString();

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<object> NotifiedUserIds { set => AddNewArrayParamValues(value, memberName: "notifiedUserId"); }
    }
}
