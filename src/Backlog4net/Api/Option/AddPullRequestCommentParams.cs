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
        public AddPullRequestCommentParams(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, string content)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.RepoIdOrName = repoIdOrName;
            this.Number = number;
            AddNewParam("content", content);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public IdOrKey RepoIdOrName { get; private set; }

        public long Number { get; private set; }

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<long> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }
    }
}
