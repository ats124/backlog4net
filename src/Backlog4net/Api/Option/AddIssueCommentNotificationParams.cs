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
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <param name="notifiedUserIds">the user identifiers for notification</param>
        public AddIssueCommentNotificationParams(IdOrKey issueIdOrKey, long commentId, IList<long> notifiedUserIds)
        {
            this.IssueIdOrKey = issueIdOrKey;
            this.CommentId = commentId;
            AddNewArrayParams("notifiedUserId[]", notifiedUserIds);
        }

        public IdOrKey IssueIdOrKey { get; private set; }

        public long CommentId { get; private set; }
    }
}
