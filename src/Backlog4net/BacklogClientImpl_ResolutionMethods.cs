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
        public Task<ResponseList<Resolution>> GetResolutionsAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
