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
        private object issueIdOrKey;

        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="content">the comment content</param>
        public AddIssueCommentParams(object issueIdOrKey, string content)
        {
            this.issueIdOrKey = issueIdOrKey;
            AddNewParam("content", content);
        }

        /// <summary>
        /// Returns the issue identifier string.
        /// </summary>
        public string IssueIdOrKeyString => issueIdOrKey.ToString();

        /// <summary>
        /// Sets the notified users.
        /// </summary>
        public IList<object> NotifiedUserIds { set => AddNewArrayParamValues(value, memberName: "notifiedUserId"); }

        /// <summary>
        /// Sets the attachment files.
        /// </summary>
        public IList<object> AttachmentIds { set => AddNewArrayParamValues(value, memberName: "attachmentId"); }
    }
}
