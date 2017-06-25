using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    partial class BacklogClientImpl
    {
        public async Task<ResponseList<User>> GetUsers(CancellationToken? token = null)
            => await Factory.CreateUserList(await Get(BuildEndpoint("users")));
    }
}
