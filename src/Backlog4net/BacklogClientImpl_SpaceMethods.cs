using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Backlog4net.Http;
    using Backlog4net.Internal.File;

    partial class BacklogClientImpl
    {
        public async Task<Space> GetSpaceAsync(CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint("space");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateSpaceAsync(response);
            }
        }

        public async Task<ResponseList<Activity>> GetSpaceActivitiesAsync(ActivityQueryParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint("space/activities");
            using (var response = await Get(url, @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateActivityListAsync(response);
            }
        }

        public async Task<Icon> GetSpaceIconAsync(CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.SpaceIconEndpoint);
            return await IconImpl.CreateaAsync(response);
        }

        public async Task<SpaceNotification> GetSpaceNotificationAsync(CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint("space/notification");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateSpaceNotificationAsync(response);
            }
        }

        public async Task<SpaceNotification> UpdateSpaceNotificationAsync(string content, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("content", content) };
            var url = BuildEndpoint("space/notification");
            using (var response = await Put(url, @params, token: token))
            using (var _ = response.Content)
            {
                return await Factory.CreateSpaceNotificationAsync(response);
            }
        }

        public async Task<DiskUsage> GetSpaceDiskUsageAsync(CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint("space/diskUsage");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateDiskUsageAsync(response);
            }
        }

        public async Task<Attachment> PostAttachmentAsync(PostAttachmentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint("space/attachment");
            using (var response = await PostMultiPart(url, @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentAsync(response);
            }
        }
    }
}
