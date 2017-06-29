using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog Priority APIs.
    /// </summary>
    public interface PriorityMethods
    {
        /// <summary>
        /// Returns the priorities.
        /// </summary>
        /// <returns>the priorities in a list.</returns>
        ResponseList<Priority> GetPriorities();
    }
}
