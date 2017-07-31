using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add category API.
    /// </summary>
    public class AddIssueCommentNotificationParams : PostParams
    {
        private object issueIdOrKey;
        private object commentId;

        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <param name="notifiedUserIds">the user identifiers for notification</param>
        public AddIssueCommentNotificationParams(object issueIdOrKey, object commentId, IList<object> notifiedUserIds)
        {
            this.issueIdOrKey = issueIdOrKey;
            this.commentId = commentId;
            AddNewArrayParams("notifiedUserId[]", notifiedUserIds);
        }

        /// <summary>
        /// Returns the comment identifier.
        /// </summary>
        public string CommentId => commentId.ToString();

        /// <summary>
        /// Returns the issue identifier string.
        /// </summary>
        public string IssueIdOrKeyString => issueIdOrKey.ToString();
    }
}
