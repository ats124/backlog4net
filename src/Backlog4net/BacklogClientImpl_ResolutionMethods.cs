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
        public async Task<ResponseList<Resolution>> GetResolutionsAsync(CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("resolutions"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateResolutionListAsync(response);
            }
        }
    }
}
