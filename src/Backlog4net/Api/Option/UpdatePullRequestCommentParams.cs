using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdatePullRequestCommentParams : PatchParams
    {
        public UpdatePullRequestCommentParams(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, long commentId, string content)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.RepoIdOrName = repoIdOrName;
            this.Number = number;
            this.CommentId = commentId;
            AddNewParam("content", content);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public IdOrKey RepoIdOrName { get; private set; }

        public long Number { get; private set; }

        public long CommentId { get; private set; }
    }
}
