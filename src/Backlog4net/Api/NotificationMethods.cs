using System;
using System.Collections.Generic;
using System.Text;

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
        ResponseList<Notification> GetNotifications();

        /// <summary>
        /// Returns the notifications.
        /// </summary>
        /// <param name="params">the query parameters</param>
        /// <returns>the notifications in a list.</returns>
        ResponseList<Notification> GetNotifications(QueryParams @params);

        /// <summary>
        /// Returns the count of the notifications.
        /// </summary>
        /// <param name="params">the notification parameters</param>
        /// <returns>the count of the notifications</returns>
        int GetNotificationCount(GetNotificationCountParams @params);

        /// <summary>
        /// Resets the count of the notifications.
        /// </summary>
        /// <returns>the count of the reset notifications</returns>
        int ResetNotificationCount();

        /// <summary>
        /// Marks the notification as already read.
        /// </summary>
        /// <param name="notificationId">the notification identifier</param>
        void MarkAsReadNotification(object notificationId);
    }
}
