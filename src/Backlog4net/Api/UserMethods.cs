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
        Task<ResponseList<User>> GetUsersAsync(CancellationToken? token = null);

        /// <summary>
        /// Returns the user in the space.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the User</returns>
        Task<User> GetUserAsync(object numericUserId, CancellationToken? token = null);

        /// <summary>
        /// Creates a user in the space.
        /// </summary>
        /// <param name="params">the creating user parameter</param>
        /// <returns>the created user</returns>
        Task<User> CreateUserAsync(CreateUserParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the user in space.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the deleted user</returns>
        Task<User> DeleteUserAsync(object numericUserId, CancellationToken? token = null);

        /// <summary>
        /// Returns the own information.
        /// </summary>
        /// <returns>the User</returns>
        Task<User> GetMyselfAsync(CancellationToken? token = null);

        /// <summary>
        /// Returns the user icon.
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the Icon</returns>
        Task<Icon> GetUserIconAsync(object numericUserId, CancellationToken? token = null);

        /// <summary>
        /// Returns the user recently updates
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the updates in a list</returns>
        Task<ResponseList<Activity>> GetUserActivitiesAsync(object numericUserId, ActivityQueryParams queryParams = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the received stars
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the stars in a list</returns>
        Task<ResponseList<Star>> GetUserStarsAsync(object numericUserId, QueryParams queryParams = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the received star count
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="params">star count parameters</param>
        /// <returns>the count of received star</returns>
        Task<int> GetUserStarCountAsync(object numericUserId, GetStarsParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the recently viewed issues
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the issues in a list</returns>
        Task<ResponseList<ViewedIssue>> GetRecentlyViewedIssuesAsync(OffsetParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the recently viewed projects
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the projects in a list</returns>
        Task<ResponseList<ViewedProject>> GetRecentlyViewedProjectsAsync(OffsetParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the recently viewed wikis
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the wikis in a list</returns>
        Task<ResponseList<ViewedWiki>> GetRecentlyViewedWikisAsync(OffsetParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Returns the received watch count
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <param name="params">watch count parameters</param>
        /// <returns>the count of received watch</returns>
        Task<int> GetUserWatchCountAsync(object numericUserId, GetWatchesParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the received watchings
        /// </summary>
        /// <param name="numericUserId">the user identifier</param>
        /// <returns>the watchings in a list</returns>
        Task<ResponseList<Watch>> GetUserWatchesAsync(object numericUserId, CancellationToken? token = null);
    }
}
