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
        public async Task<int> GetNotificationCountAsync(GetNotificationCountParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("notifications/count"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<Notification>> GetNotificationsAsync(QueryParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("notifications"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateNotificationListAsync(response);
            }
        }

        public async Task MarkAsReadNotificationAsync(long notificationId, CancellationToken? token = default(CancellationToken?))
        {
            (await Post(BuildEndpoint($"notifications/{notificationId}/markAsRead"), token: token)).Dispose();
        }

        public async Task<int> ResetNotificationCountAsync(CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint("notifications/markAsRead"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }
    }
}
