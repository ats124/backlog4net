using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;

    partial class BacklogClientImpl
    {
        public async Task<Issue> ImportIssueAsync(ImportIssueParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"issues/import"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueAsync(response);
            }
        }

        public async Task<Issue> ImportUpdateIssueAsync(ImportUpdateIssueParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"issues/{@params.IssueIdOrKeyString}/import"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueAsync(response);
            }
        }

        public async Task<Wiki> ImportWikiAsync(ImportWikiParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"wikis/import"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiAsync(response);
            }
        }
    }
}
