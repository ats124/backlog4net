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
        public async Task<ResponseList<Repository>> GetGitRepositoriesAsync(IdOrKey projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new GetRepositoriesParams(projectIdOrKey.ToString());
            using (var response = await Get(BuildEndpoint("git/repositories"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateRepositoryListAsync(response);
            }
        }

        public async Task<Repository> GetGitRepositoryAsync(IdOrKey projectIdOrKey, IdOrKey repoIdOrName, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateRepositoryAsync(response);
            }
        }
    }
}
