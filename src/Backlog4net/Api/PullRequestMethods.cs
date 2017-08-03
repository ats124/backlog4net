using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Pull Request APIs.
    /// </summary>
    public interface PullRequestMethods
    {
        /// <summary>
        /// Returns the pull requests of the repository.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="params">the finding pull request parameters.</param>
        /// <returns>the git pull requests in a list.</returns>
        Task<ResponseList<PullRequest>> GetPullRequestsAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, PullRequestQueryParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the count of the pull requests.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="params">the finding pull request parameters.</param>
        /// <returns>the git pull request.</returns>
        Task<int> GetPullRequestCountAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, PullRequestQueryParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Add a pull request.
        /// </summary>
        /// <param name="params">the pull request adding parameters</param>
        /// <returns>the git pull request.</returns>
        Task<PullRequest> AddPullRequestAsync(AddPullRequestParams @params, CancellationToken? token = null);

        /// <summary>
        /// Update a pull request.
        /// </summary>
        /// <param name="params">the pull request updating parameters</param>
        /// <returns>the git pull request</returns>
        Task<PullRequest> UpdatePullRequestAsync(UpdatePullRequestParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the git pull requests in a list.</returns>
        Task<PullRequest> GetPullRequestAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, CancellationToken? token = null);

        /// <summary>
        /// Returns the comments of pull requests.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="params">the finding pull request comments parameters.</param>
        /// <returns>the git pull requests in a list.</returns>
        Task<ResponseList<PullRequestComment>> GetPullRequestCommentsAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, QueryParams @params, CancellationToken? token = null);

        /// <summary>
        /// Add a comment on the pull request.
        /// </summary>
        /// <param name="params">the adding pull request comment parameters.</param>
        /// <returns>the added pull request comment.</returns>
        Task<PullRequestComment> AddPullRequestCommentAsync(AddPullRequestCommentParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the pull request comment count.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the pull request comment count</returns>
        Task<int> GetPullRequestCommentCountAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, CancellationToken? token = null);

        /// <summary>
        /// Updates the pull request comment.
        /// </summary>
        /// <param name="params">the pull request comment updating parameters</param>
        /// <returns>the pull request comment.</returns>
        Task<PullRequestComment> UpdatePullRequestCommentAsync(UpdatePullRequestCommentParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the pull request attachment list.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the pull request attachment list</returns>
        Task<ResponseList<Attachment>> GetPullRequestAttachmentsAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, CancellationToken? token = null);

        /// <summary>
        /// Returns the attachment file data on the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="attachmentId">the pull request attachment identifier</param>
        /// <returns>the attachment file data</returns>
        Task<AttachmentData> DownloadPullRequestAttachmentAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, long attachmentId, CancellationToken? token = null);

        /// <summary>
        /// Deletes the attachment file on the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="attachmentId">the pull request attachment identifier</param>
        /// <returns>Attachmentreturns>
        Task<Attachment> DeletePullRequestAttachmentAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, long number, long attachmentId, CancellationToken? token = null);
    }
}
