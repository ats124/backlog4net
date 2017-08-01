using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueCommentParams : PatchParams
    {
        public UpdateIssueCommentParams(IdOrKey issueIdOrKey, long commentId, string content)
        {
            this.IssueIdOrKey = issueIdOrKey;
            this.CommentId = commentId;
            AddNewParam("content", content);
        }

        public IdOrKey IssueIdOrKey { get; private set; }

        public long CommentId { get; private set; }
    }
}
