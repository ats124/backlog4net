using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    partial class BacklogClientImpl
    {
        public async Task<ResponseList<User>> GetUsersAsync(CancellationToken? token = null)
            => await Factory.CreateUserListAsync(await Get(BuildEndpoint("users")));
    }
}
