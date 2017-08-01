using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add issue comment API.
    /// </summary>
    public class AddIssueCommentParams : PostParams
    {
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="content">the comment content</param>
        public AddIssueCommentParams(IdOrKey issueIdOrKey, string content)
        {
            this.IssueIdOrKey = issueIdOrKey;
            AddNewParam("content", content);
        }

        public IdOrKey IssueIdOrKey { get; private set; }

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
