using System;
using System.Collections.Generic;
using System.Text;

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
        Space GetSpace();

        /// <summary>
        /// Returns the activities in the space.
        /// </summary>
        /// <returns>the activities in a list</returns>
        ResponseList<Activity> GetSpaceActivities();

        /// <summary>
        /// Returns the activities in the space.
        /// </summary>
        /// <param name="params">the query parameters</param>
        /// <returns>the activities in a list</returns>
        ResponseList<Activity> GetSpaceActivities(ActivityQueryParams @params);

        /// <summary>
        /// Returns the space icon.
        /// </summary>
        /// <returns>the Icon</returns>
        Icon GetSpaceIcon();

        /// <summary>
        /// Returns the space information.
        /// </summary>
        /// <returns>the SpaceNotification</returns>
        SpaceNotification GetSpaceNotification();

        /// <summary>
        /// Updates the space information.
        /// </summary>
        /// <param name="content">information</param>
        /// <returns>the updated space information</returns>
        SpaceNotification UpdateSpaceNotification(string content);

        /// <summary>
        /// Returns the disk usage of the project.
        /// </summary>
        /// <returns>the DiskUsage</returns>
        DiskUsage GetSpaceDiskUsage();

        /// <summary>
        /// Posts the attachment file for issue or wiki.
        /// </summary>
        /// <param name="attachmentData">the attachment file data</param>
        /// <returns></returns>
        Attachment PostAttachment(AttachmentData attachmentData);

    }
}
