using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Notification APIs.
    /// </summary>
    public interface NotificationMethods
    {
        /// <summary>
        ///  Returns the notifications.
        /// </summary>
        /// <returns>the notifications in a list.</returns>
        Task<ResponseList<Notification>> GetNotificationsAsync(CancellationToken? token = null);

        /// <summary>
        /// Returns the notifications.
        /// </summary>
        /// <param name="params">the query parameters</param>
        /// <returns>the notifications in a list.</returns>
        Task<ResponseList<Notification>> GetNotificationsAsync(QueryParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the count of the notifications.
        /// </summary>
        /// <param name="params">the notification parameters</param>
        /// <returns>the count of the notifications</returns>
        Task<int> GetNotificationCountAsync(GetNotificationCountParams @params, CancellationToken? token = null);

        /// <summary>
        /// Resets the count of the notifications.
        /// </summary>
        /// <returns>the count of the reset notifications</returns>
        Task<int> ResetNotificationCountAsync(CancellationToken? token = null);

        /// <summary>
        /// Marks the notification as already read.
        /// </summary>
        /// <param name="notificationId">the notification identifier</param>
        Task MarkAsReadNotificationAsync(object notificationId, CancellationToken? token = null);
    }
}
