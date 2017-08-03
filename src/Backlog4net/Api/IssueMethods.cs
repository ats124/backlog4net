using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        Task<ResponseList<Issue>> GetIssuesAsync(GetIssuesParams @params, CancellationToken? token = null);

        /// <summary>
        /// Finds and returns all the issues count.
        /// </summary>
        /// <param name="params">the finding issue parameters</param>
        /// <returns>the issues count.</returns>
        Task<int> GetIssuesCountAsync(GetIssuesCountParams @params, CancellationToken? token = null);

        /// <summary>
        /// Creates a issue.
        /// </summary>
        /// <param name="params">the issue creating parameters</param>
        /// <returns>the created Issue</returns>
        Task<Issue> CreateIssueAsync(CreateIssueParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the Issue</returns>
        Task<Issue> GetIssueAsync(IdOrKey issueIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Updates an existing issue.
        /// </summary>
        /// <param name="params">the issue updating parameters</param>
        /// <returns>the updated Issue</returns>
        Task<Issue> UpdateIssueAsync(UpdateIssueParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the deleted Issue</returns>
        Task<Issue> DeleteIssueAsync(IdOrKey issueIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the issue comments.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the issue's comments in a list.</returns>
        Task<ResponseList<IssueComment>> GetIssueCommentsAsync(IdOrKey issueIdOrKey, QueryParams queryParams = null, CancellationToken? token = null);

        /// <summary>
        /// Adds a issue comment.
        /// </summary>
        /// <param name="params">the issue comment adding parameters</param>
        /// <returns>the added IssueComment</returns>
        Task<IssueComment> AddIssueCommentAsync(AddIssueCommentParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the count of the issue comments.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>count of the issue comments.</returns>
        Task<int> GetIssueCommentCountAsync(IdOrKey issueIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the issue comment.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <returns>the issue comment</returns>
        Task<IssueComment> GetIssueCommentAsync(IdOrKey issueIdOrKey, long commentId, CancellationToken? token = null);

        /// <summary>
        /// Updates an existing issue comment.
        /// </summary>
        /// <param name="params">the issue comment updating parameters.</param>
        /// <returns>the updated IssueComment</returns>
        Task<IssueComment> UpdateIssueCommentAsync(UpdateIssueCommentParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the issue comment notifications.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="commentId">the comment identifier</param>
        /// <returns>the issue comment notifications</returns>
        Task<ResponseList<Notification>> GetIssueCommentNotificationsAsync(IdOrKey issueIdOrKey, long commentId, CancellationToken? token = null);

        /// <summary>
        /// Adds a issue comment notification.
        /// </summary>
        /// <param name="params">the issue comment notification adding parameters</param>
        /// <returns>the issue comment</returns>
        Task<IssueComment> AddIssueCommentNotificationAsync(AddIssueCommentNotificationParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns all the attachments on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <returns>the attachments in a list.</returns>
        Task<ResponseList<Attachment>> GetIssueAttachmentsAsync(IdOrKey issueIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the attachment file data on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="attachmentId">the attachment identifier</param>
        /// <returns>the AttachmentData</returns>
        Task<AttachmentData> DownloadIssueAttachmentAsync(IdOrKey issueIdOrKey, long attachmentId, CancellationToken? token = null);

        /// <summary>
        /// Deletes the attachment file on the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="attachmentId">the attachment identifier</param>
        /// <returns>the Attachment</returns>
        Task<Attachment> DeleteIssueAttachmentAsync(IdOrKey issueIdOrKey, long attachmentId, CancellationToken? token = null);

        /// <summary>
        /// Returns all the shared files on the issue.
        /// </summary>
        /// <param name="issueIdOrKey"the issue identifier></param>
        /// <returns>shared files in a list.</returns>
        Task<ResponseList<SharedFile>> GetIssueSharedFilesAsync(IdOrKey issueIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// links the shared files to the issue.
        /// </summary>
        /// <param name="issueIdOrKey">issueIdOrKey the issue identifier</param>
        /// <param name="fileIds">fileIds  the file identifiers in a list</param>
        /// <returns>the linked shared files in a list.</returns>
        Task<ResponseList<SharedFile>> LinkIssueSharedFileAsync(IdOrKey issueIdOrKey, long[] fileIds, CancellationToken? token = null);

        /// <summary>
        /// Deletes link of the shared file from the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="fileId">the file identifiers</param>
        /// <returns>the unlinked SharedFile</returns>
        Task<SharedFile> UnlinkIssueSharedFileAsync(IdOrKey issueIdOrKey, long fileId, CancellationToken? token = null);
    }
}
