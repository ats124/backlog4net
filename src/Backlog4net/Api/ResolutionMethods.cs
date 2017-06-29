using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog Resolution APIs.
    /// </summary>
    public interface ResolutionMethods
    {
        /// <summary>
        /// Returns the resolutions.
        /// </summary>
        /// <returns>the resolutions in a list</returns>
        ResponseList<Resolution> GetResolutions();
    }
}
