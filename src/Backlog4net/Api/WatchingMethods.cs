using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Watch APIs.
    /// </summary>
    public interface WatchingMethods
    {
        /// <summary>
        /// Returns the Watch.
        /// </summary>
        /// <param name="watchingId">watchingId</param>
        /// <returns>the Watch</returns>
        Task<Watch> GetWatchAsync(long watchingId, CancellationToken? token = null);

        /// <summary>
        /// Adds a watching to the issue.
        /// </summary>
        /// <param name="issueIdOrKey">the issue identifier</param>
        /// <param name="note">note</param>
        /// <returns></returns>
        Task<Watch> AddWatchToIssueAsync(IdOrKey issueIdOrKey, String note, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing watching.
        /// </summary>
        /// <param name="params">the updating project parameters</param>
        /// <returns>the updated Watching</returns>
        Task<Watch> UpdateWatchAsync(UpdateWatchParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the existing watching.
        /// </summary>
        /// <param name="watchingId">the watching identifier</param>
        /// <returns>the deleted watching</returns>
        Task<Watch> DeleteWatchAsync(long watchingId, CancellationToken? token = null);

        /// <summary>
        /// Marks the watching as already read.
        /// </summary>
        /// <param name="numericUserId">Marks the watching as already read.</param>
        Task MarkAsCheckedUserWatchesAsync(long numericUserId, CancellationToken? token = null);
    }
}
