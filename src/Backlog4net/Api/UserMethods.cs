using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog User APIs.
    /// </summary>
    public interface UserMethods
    {
        /// <summary>
        /// Returns all the users in the space.
        /// </summary>
        /// <returns>the users in a list</returns>
        ResponseList<User> GetUsers();

        /// <summary>
        /// Returns the user in the space.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the User</returns>
        User GetUser(object numericUserId);

        /// <summary>
        /// Creates a user in the space.
        /// </summary>
        /// <param name="params">the creating user parameter</param>
        /// <returns>the created user</returns>
        User CreateUser(CreateUserParams @params);

        /// <summary>
        /// Deletes the user in space.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the deleted user</returns>
        User DeleteUser(object numericUserId);

        /// <summary>
        /// Returns the own information.
        /// </summary>
        /// <returns>the User</returns>
        User GetMyself();

        /// <summary>
        /// Returns the user icon.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the Icon</returns>
        Icon GetUserIcon(object numericUserId);

        /// <summary>
        /// Returns the user recently updates
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the updates in a list</returns>
        ResponseList<Activity> GetUserActivities(object numericUserId);

        /// <summary>
        /// Returns the user recently updates
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the updates in a list</returns>
        ResponseList<Activity> GetUserActivities(object numericUserId, ActivityQueryParams queryParams);

        /// <summary>
        /// Returns the received stars
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the stars in a list</returns>
        ResponseList<Star> GetUserStars(object numericUserId);

        /// <summary>
        /// Returns the received stars
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the stars in a list</returns>
        ResponseList<Star> GetUserStars(object numericUserId, QueryParams queryParams);

        /// <summary>
        /// Returns the received star count
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="params">star count parameters</param>
        /// <returns>the count of received star</returns>
        int GetUserStarCount(object numericUserId, GetStarsParams @params);

        /// <summary>
        /// Returns the recently viewed issues
        /// </summary>
        /// <returns>the issues in a list</returns>
        ResponseList<ViewedIssue> GetRecentlyViewedIssues();

        /// <summary>
        /// Returns the recently viewed issues
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the issues in a list</returns>
        ResponseList<ViewedIssue> GetRecentlyViewedIssues(OffsetParams @params);

        /// <summary>
        /// Returns the recently viewed projects
        /// </summary>
        /// <returns>the projects in a list</returns>
        ResponseList<ViewedProject> GetRecentlyViewedProjects();

        /// <summary>
        /// Returns the recently viewed projects
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the projects in a list</returns>
        ResponseList<ViewedProject> GetRecentlyViewedProjects(OffsetParams @params);

        /// <summary>
        /// Returns the recently viewed wikis
        /// </summary>
        /// <returns>the wikis in a list</returns>
        ResponseList<ViewedWiki> GetRecentlyViewedWikis();

        /// <summary>
        /// Returns the recently viewed wikis
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the wikis in a list</returns>
        ResponseList<ViewedWiki> GetRecentlyViewedWikis(OffsetParams @params);

        /// <summary>
        /// Returns the received watch count
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="params">watch count parameters</param>
        /// <returns>the count of received watch</returns>
        int GetUserWatchCount(object numericUserId, GetWatchesParams @params);

        /// <summary>
        /// Returns the received watchings
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the watchings in a list</returns>
        ResponseList<Watch> GetUserWatches(object numericUserId);
    }
}
