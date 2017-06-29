using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Issue APIs.
    /// </summary>
    public interface IssueMethods
    {
        /// <summary>
        /// Finds and returns all the issues.
        /// </summary>
        /// <param name="params">the finding issue parameters</param>
        /// <returns>the issues in a list.</returns>
        ResponseList<Issue> GetIssues(GetIssuesParams @params);

        /// <summary>
        /// Finds and returns all the issues count.
        /// </summary>
        /// <param name="params">the finding issue parameters</param>
        /// <returns>the issues count.</returns>
        int GetIssuesCount(GetIssuesCountParams @params);

        /// <summary>
        /// Creates a issue.
        /// </summary>
        /// <param name="params">the issue creating parameters</param>
        /// <returns>the created Issue</returns>
        Issue CreateIssue(CreateIssueParams @params);

        /// <summary>
        /// Returns the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the Issue</returns>
        Issue GetIssue(object issueIdOrKey);

        /// <summary>
        /// Updates an existing issue.
        /// </summary>
        /// <param name="params">the issue updating parameters</param>
        /// <returns>the updated Issue</returns>
        Issue UpdateIssue(UpdateIssueParams @params);

        /// <summary>
        /// Deletes the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the deleted Issue</returns>
        Issue DeleteIssue(object issueIdOrKey);

        /// <summary>
        /// Returns the issue comments.
        /// </summary>
        /// <param name="issueIdOrkey">the issue identifier</param>
        /// <returns>the issue's comments in a list.</returns>
        ResponseList<IssueComment> GetIssueComments(object issueIdOrkey);

        /// <summary>
        /// Returns the issue comments.
        /// </summary>
        /// <param name="issueIdOrkey">the issue identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the issue's comments in a list.</returns>
        ResponseList<IssueComment> GetIssueComments(object issueIdOrkey, QueryParams queryParams);

        /// <summary>
        /// Adds a issue comment.
        /// </summary>
        /// <param name="params">the issue comment adding parameters</param>
        /// <returns>the added IssueComment</returns>
        IssueComment AddIssueComment(AddIssueCommentParams @params);

        /// <summary>
        /// Returns the count of the issue comments.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>count of the issue comments.</returns>
        int GetIssueCommentCount(object issueIdOrKey);

        /// <summary>
        /// Returns the issue comment.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <returns>the issue comment</returns>
        IssueComment GetIssueComment(object issueIdOrKey, object commentId);

        /// <summary>
        /// Updates an existing issue comment.
        /// </summary>
        /// <param name="params">the issue comment updating parameters.</param>
        /// <returns>the updated IssueComment</returns>
        IssueComment UpdateIssueComment(UpdateIssueCommentParams @params);

        /// <summary>
        /// Returns the issue comment notifications.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <returns>the issue comment notifications</returns>
        ResponseList<Notification> GetIssueCommentNotifications(object issueIdOrKey, object commentId);

        /// <summary>
        /// Adds a issue comment notification.
        /// </summary>
        /// <param name="params">the issue comment notification adding parameters</param>
        /// <returns>the issue comment</returns>
        IssueComment AddIssueCommentNotification(AddIssueCommentNotificationParams @params);

        /// <summary>
        /// Returns all the attachments on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the attachments in a list.</returns>
        ResponseList<Attachment> GetIssueAttachments(object issueIdOrKey);

        /// <summary>
        /// Returns the attachment file data on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="attachmentId">the attachment identifier</param>
        /// <returns>the AttachmentData</returns>
        AttachmentData DownloadIssueAttachment(object issueIdOrKey, object attachmentId);

        /// <summary>
        /// Deletes the attachment file on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="attachmentId">the attachment identifier</param>
        /// <returns>the Attachment</returns>
        Attachment DeleteIssueAttachment(object issueIdOrKey, object attachmentId);

        /// <summary>
        /// Returns all the shared files on the issue.
        /// </summary>
        /// <param name="issueIdOrKey"the issue identifier></param>
        /// <returns>shared files in a list.</returns>
        ResponseList<SharedFile> GetIssueSharedFiles(object issueIdOrKey);

        /// <summary>
        /// links the shared files to the issue.
        /// </summary>
        /// <param name="issueIdOrKey">issueIdOrKey the issue identifier</param>
        /// <param name="fileIds">fileIds  the file identifiers in a list</param>
        /// <returns>the linked shared files in a list.</returns>
        ResponseList<SharedFile> LinkIssueSharedFile(Object issueIdOrKey, object[] fileIds);

        /// <summary>
        /// Deletes link of the shared file from the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="fileId">the file identifiers</param>
        /// <returns>the unlinked SharedFile</returns>
        SharedFile UnlinkIssueSharedFile(object issueIdOrKey, object fileId);
    }
}
