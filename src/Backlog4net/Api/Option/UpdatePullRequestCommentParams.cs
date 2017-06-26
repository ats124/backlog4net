using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdatePullRequestCommentParams : PatchParams
    {
        private object projectIdOrKey;
        private object repoIdOrName;
        private object number;
        private object commentId;

        public UpdatePullRequestCommentParams(object projectIdOrKey, object repoIdOrName, object number, object commentId, string content)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.repoIdOrName = repoIdOrName;
            this.number = number;
            this.commentId = commentId;
            AddNewParam("content", content);
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string RepoIdOrName => repoIdOrName.ToString();

        public string Number => number.ToString();

        public string CommentId => commentId.ToString();

        public IList<object> NotifiedUserIds { set => AddNewArrayParams("notifiedUserId[]", value); }
    }
}
