using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Issue APIs.
    /// </summary>
    public interface ImportMethods
    {
        Task<Issue> ImportIssueAsync(ImportIssueParams @params, CancellationToken? token = null);

        Task<Issue> ImportUpdateIssueAsync(ImportUpdateIssueParams @params, CancellationToken? token = null);

        Task<Wiki> ImportWikiAsync(ImportWikiParams @params, CancellationToken? token = null);
    }
}
