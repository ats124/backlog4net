using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Space APIs.
    /// </summary>
    public interface SpaceMethods
    {
        /// <summary>
        /// Returns the Space.
        /// </summary>
        /// <returns>the Space</returns>
        Task<Space> GetSpaceAsync(CancellationToken? token = null);

        /// <summary>
        /// Returns the activities in the space.
        /// </summary>
        /// <param name="params">the query parameters</param>
        /// <returns>the activities in a list</returns>
        Task<ResponseList<Activity>> GetSpaceActivitiesAsync(ActivityQueryParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the space icon.
        /// </summary>
        /// <returns>the Icon</returns>
        Task<Icon> GetSpaceIconAsync(CancellationToken? token = null);

        /// <summary>
        /// Returns the space information.
        /// </summary>
        /// <returns>the SpaceNotification</returns>
        Task<SpaceNotification> GetSpaceNotificationAsync(CancellationToken? token = null);

        /// <summary>
        /// Updates the space information.
        /// </summary>
        /// <param name="content">information</param>
        /// <returns>the updated space information</returns>
        Task<SpaceNotification> UpdateSpaceNotificationAsync(string content, CancellationToken? token = null);

        /// <summary>
        /// Returns the disk usage of the project.
        /// </summary>
        /// <returns>the DiskUsage</returns>
        Task<DiskUsage> GetSpaceDiskUsageAsync(CancellationToken? token = null);

        /// <summary>
        /// Posts the attachment file for issue or wiki.
        /// </summary>
        /// <param name="@params">file post parameters</param>
        /// <returns>the Attachment</returns>
        Task<Attachment> PostAttachmentAsync(PostAttachmentParams @params, CancellationToken? token = null);

    }
}
