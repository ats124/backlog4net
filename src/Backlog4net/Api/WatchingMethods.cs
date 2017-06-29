using System;
using System.Collections.Generic;
using System.Text;

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
        Watch GetWatch(long watchingId);

        /// <summary>
        /// Adds a watching to the issue.
        /// </summary>
        /// <param name="watchingId">the issue identifier</param>
        /// <param name="note">note</param>
        /// <returns></returns>
        Watch AddWatchToIssue(object watchingId, String note);

        /// <summary>
        /// Updates the existing watching.
        /// </summary>
        /// <param name="params">the updating project parameters</param>
        /// <returns>the updated Watching</returns>
        Watch UpdateWatch(UpdateWatchParams @params);

        /// <summary>
        /// Deletes the existing watching.
        /// </summary>
        /// <param name="watchingId">the watching identifier</param>
        /// <returns>the deleted watching</returns>
        Watch DeleteWatch(object watchingId);

        /// <summary>
        /// Marks the watching as already read.
        /// </summary>
        /// <param name="numericUserId">Marks the watching as already read.</param>
        void MarkAsCheckedUserWatches(object numericUserId);
    }
}
