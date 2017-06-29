using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        Task<ResponseList<Resolution>> GetResolutionsAsync(CancellationToken? token = null);
    }
}
