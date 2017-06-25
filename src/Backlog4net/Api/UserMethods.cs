using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog User APIs.
    /// </summary>
    public interface UserMethods
    {
        Task<ResponseList<User>> GetUsers(CancellationToken? token = null);
    }
}
