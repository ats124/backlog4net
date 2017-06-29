using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Issue APIs.
    /// </summary>
    public interface ImportMethods
    {
        Issue ImportIssue(ImportIssueParams @params);

        Issue ImportUpdateIssue(ImportUpdateIssueParams @params);

        Wiki ImportWiki(ImportWikiParams @params);
    }
}
