using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateIssueCommentParams : PatchParams
    {
        private object issueIdOrKey;
        private object commentId;

        public UpdateIssueCommentParams(object issueIdOrKey, object commentId, string content)
        {
            this.issueIdOrKey = issueIdOrKey;
            AddNewParam("content", content);
        }

        public string IssueIdOrKeyString => issueIdOrKey.ToString();

        public string CommentId => commentId.ToString();
    }
}
