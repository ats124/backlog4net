using System;
using System.Collections.Generic;
using System.Text;

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
        /// <returns>the git pull requests in a list.</returns>
        ResponseList<PullRequest> GetPullRequests(object projectIdOrKey, object repoIdOrName);

        /// <summary>
        /// Returns the pull requests of the repository.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="params">the finding pull request parameters.</param>
        /// <returns>the git pull requests in a list.</returns>
        ResponseList<PullRequest> GetPullRequests(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params);

        /// <summary>
        /// Returns the count of the pull requests.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <returns>the git pull request.</returns>
        int GetPullRequestCount(object projectIdOrKey, object repoIdOrName);

        /// <summary>
        /// Returns the count of the pull requests.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="params">the finding pull request parameters.</param>
        /// <returns>the git pull request.</returns>
        int GetPullRequestCount(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params);

        /// <summary>
        /// Add a pull request.
        /// </summary>
        /// <param name="params">the pull request adding parameters</param>
        /// <returns>the git pull request.</returns>
        PullRequest AddPullRequest(AddPullRequestParams @params);

        /// <summary>
        /// Update a pull request.
        /// </summary>
        /// <param name="params">the pull request updating parameters</param>
        /// <returns>the git pull request</returns>
        PullRequest UpdatePullRequest(UpdatePullRequestParams @params);

        /// <summary>
        /// Returns the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the git pull requests in a list.</returns>
        PullRequest GetPullRequest(object projectIdOrKey, object repoIdOrName, object number);

        /// <summary>
        /// Returns the comments of pull requests.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="params">the finding pull request comments parameters.</param>
        /// <returns>the git pull requests in a list.</returns>
        ResponseList<PullRequestComment> GetPullRequestComments(object projectIdOrKey, object repoIdOrName, object number, QueryParams @params);

        /// <summary>
        /// Add a comment on the pull request.
        /// </summary>
        /// <param name="params">the adding pull request comment parameters.</param>
        /// <returns>the added pull request comment.</returns>
        PullRequestComment AddPullRequestComment(AddPullRequestCommentParams @params);

        /// <summary>
        /// Returns the pull request comment count.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the pull request comment count</returns>
        int GetPullRequestCommentCount(object projectIdOrKey, object repoIdOrName, object number);

        /// <summary>
        /// Updates the pull request comment.
        /// </summary>
        /// <param name="params">the pull request comment updating parameters</param>
        /// <returns>the pull request comment.</returns>
        PullRequestComment UpdatePullRequestComment(UpdatePullRequestCommentParams @params);

        /// <summary>
        /// Returns the pull request attachment list.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <returns>the pull request attachment list</returns>
        ResponseList<Attachment> GetPullRequestAttachments(object projectIdOrKey, object repoIdOrName, object number);

        /// <summary>
        /// Returns the attachment file data on the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="attachmentId">the pull request attachment identifier</param>
        /// <returns>the attachment file data</returns>
        AttachmentData DownloadPullRequestAttachment(object projectIdOrKey, object repoIdOrName, object number, object attachmentId);

        /// <summary>
        /// Deletes the attachment file on the pull request.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <param name="number">the pull request identifier</param>
        /// <param name="attachmentId">the pull request attachment identifier</param>
        /// <returns>Attachmentreturns>
        Attachment DeletePullRequestAttachment(object projectIdOrKey, object repoIdOrName, object number, object attachmentId);
    }
}
