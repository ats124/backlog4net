using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog Star APIs.
    /// </summary>
    public interface StarMethods
    {
        /// <summary>
        /// Adds a star to the issue.
        /// </summary>
        /// <param name="issueId">the issue identifier</param>
        void AddStarToIssue(object issueId);

        /// <summary>
        /// Adds a star to the issue comment.
        /// </summary>
        /// <param name="commentId">comment identifier</param>
        void AddStarToComment(object commentId);

        /// <summary>
        /// Adds a star to the wiki.
        /// </summary>
        /// <param name="wikiId">the wiki identifier</param>
        void AddStarToWiki(object wikiId);

        /// <summary>
        /// Adds a star to the pull request.
        /// </summary>
        /// <param name="pullRequestId">the pull request identifier</param>
        void AddStarToPullRequest(object pullRequestId);

        /// <summary>
        /// Adds a star to the pull request comment.
        /// </summary>
        /// <param name="pullRequestCommentId">the pull request comment identifier</param>
        void AddStarToPullRequestComment(object pullRequestCommentId);
    }
}
