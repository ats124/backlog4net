using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Internal.File;

    partial class BacklogClientImpl
    {
        public async Task<ResponseList<User>> GetUsersAsync(CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("users"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserListAsync(response);
            }
        }

        public async Task<User> GetUserAsync(long numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<User> CreateUserAsync(CreateUserParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"users"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<User> DeleteUserAsync(long numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"users/{numericUserId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<User> GetMyselfAsync(CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("users/myself"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateUserAsync(response);
            }
        }

        public async Task<Icon> GetUserIconAsync(long numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.UserIconEndpoint(numericUserId));
            return await IconImpl.CreateaAsync(response);
        }

        public async Task<ResponseList<Activity>> GetUserActivitiesAsync(long numericUserId, ActivityQueryParams queryParams = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}/activities"), queryParams, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateActivityListAsync(response);
            }
        }

        public async Task<ResponseList<Star>> GetUserStarsAsync(long numericUserId, QueryParams queryParams = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}/stars"), queryParams, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateStarListAsync(response);
            }
        }

        public async Task<int> GetUserStarCountAsync(long numericUserId, GetStarsParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}/stars/count"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<ViewedIssue>> GetRecentlyViewedIssuesAsync(OffsetParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/myself/recentlyViewedIssues"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateViewedIssueListAsync(response);
            }
        }

        public async Task<ResponseList<ViewedProject>> GetRecentlyViewedProjectsAsync(OffsetParams @params = null, CancellationToken? token = null)
        {
            using (var response = await Get(BuildEndpoint($"users/myself/recentlyViewedProjects"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateViewedProjectListAsync(response);
            }
        }


        public async Task<ResponseList<ViewedWiki>> GetRecentlyViewedWikisAsync(OffsetParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/myself/recentlyViewedWikis"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateViewedWikiListAsync(response);
            }
        }

        public async Task<int> GetUserWatchCountAsync(long numericUserId, GetWatchCountParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}/watchings/count"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<Watch>> GetUserWatchesAsync(long numericUserId, GetWatchesParams @params = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"users/{numericUserId}/watchings"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWatchListAsync(response);
            }
        }
    }
}
