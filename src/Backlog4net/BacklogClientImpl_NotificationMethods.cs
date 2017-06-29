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
        public Task<int> GetNotificationCountAsync(GetNotificationCountParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Notification>> GetNotificationsAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Notification>> GetNotificationsAsync(QueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task MarkAsReadNotificationAsync(object notificationId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> ResetNotificationCountAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
