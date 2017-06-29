using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog Status APIs.
    /// </summary>
    public interface StatusMethods
    {
        /// <summary>
        /// Returns the statuses.
        /// </summary>
        /// <returns>the statuses in a list</returns>
        ResponseList<Status> GetStatuses();
    }
}
