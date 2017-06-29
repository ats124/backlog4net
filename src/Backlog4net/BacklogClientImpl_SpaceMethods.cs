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
        public Task<ResponseList<Activity>> GetSpaceActivitiesAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Activity>> GetSpaceActivitiesAsync(ActivityQueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Space> GetSpaceAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<DiskUsage> GetSpaceDiskUsageAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Icon> GetSpaceIconAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SpaceNotification> GetSpaceNotificationAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> PostAttachmentAsync(AttachmentData attachmentData, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SpaceNotification> UpdateSpaceNotificationAsync(string content, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
