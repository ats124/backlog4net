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
        public async Task<Group> CreateGroupAsync(CreateGroupParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint("groups"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateGroupAsync(response);
            }
        }

        public async Task<Group> DeleteGroupAsync(object groupId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"groups/{groupId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateGroupAsync(response);
            }
        }

        public async Task<Group> GetGroupAsync(object groupId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"groups/{groupId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateGroupAsync(response);
            }
        }

        public async Task<ResponseList<Group>> GetGroupsAsync(OffsetParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"groups"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateGroupListAsync(response);
            }
        }

        public async Task<Group> UpdateGroupAsync(UpdateGroupParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"groups/{@params.GroupId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateGroupAsync(response);
            }
        }
    }
}
