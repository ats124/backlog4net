using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        Task AddStarToIssueAsync(object issueId, CancellationToken? token = null);

        /// <summary>
        /// Adds a star to the issue comment.
        /// </summary>
        /// <param name="commentId">comment identifier</param>
        Task AddStarToCommentAsync(object commentId, CancellationToken? token = null);

        /// <summary>
        /// Adds a star to the wiki.
        /// </summary>
        /// <param name="wikiId">the wiki identifier</param>
        Task AddStarToWikiAsync(object wikiId, CancellationToken? token = null);

        /// <summary>
        /// Adds a star to the pull request.
        /// </summary>
        /// <param name="pullRequestId">the pull request identifier</param>
        Task AddStarToPullRequestAsync(object pullRequestId, CancellationToken? token = null);

        /// <summary>
        /// Adds a star to the pull request comment.
        /// </summary>
        /// <param name="pullRequestCommentId">the pull request comment identifier</param>
        Task AddStarToPullRequestCommentAsync(object pullRequestCommentId, CancellationToken? token = null);
    }
}
