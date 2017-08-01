using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Http;

    partial class BacklogClientImpl
    {
        public async Task<Watch> GetWatchAsync(long watchingId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"watchings/{watchingId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWatchAsync(response);
            }
        }

        public async Task<Watch> AddWatchToIssueAsync(object issueIdOrKey, string note, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new List<NameValuePair>();
            @params.Add(new NameValuePair("issueIdOrKey", issueIdOrKey.ToString()));
            if (note != null) @params.Add(new NameValuePair("note", note));
            using (var response = await Post(BuildEndpoint($"watchings"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWatchAsync(response);
            }
        }

        public async Task<Watch> UpdateWatchAsync(UpdateWatchParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"watchings/{@params.WatchingId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWatchAsync(response);
            }
        }

        public async Task<Watch> DeleteWatchAsync(object watchingId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"watchings/{watchingId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWatchAsync(response);
            }
        }

        public async Task MarkAsCheckedUserWatchesAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"users/{numericUserId}/watchings/markAsChecked"), token: token))
            {
                response.Content.Dispose();
            }
        }
    }
}
