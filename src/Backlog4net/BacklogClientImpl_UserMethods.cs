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
        //public async Task<ResponseList<User>> GetUsersAsync(CancellationToken? token = null)
        //    => await Factory.CreateUserListAsync(await Get(BuildEndpoint("users")));
        public Task<User> CreateUserAsync(CreateUserParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUserAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> GetMyselfAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedIssue>> GetRecentlyViewedIssuesAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedIssue>> GetRecentlyViewedIssuesAsync(OffsetParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedProject>> GetRecentlyViewedProjectsAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedProject>> GetRecentlyViewedProjectsAsync(OffsetParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedWiki>> GetRecentlyViewedWikisAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<ViewedWiki>> GetRecentlyViewedWikisAsync(OffsetParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Activity>> GetUserActivitiesAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Activity>> GetUserActivitiesAsync(object numericUserId, ActivityQueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Icon> GetUserIconAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<User>> GetUsersAsync(CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserStarCountAsync(object numericUserId, GetStarsParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Star>> GetUserStarsAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Star>> GetUserStarsAsync(object numericUserId, QueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserWatchCountAsync(object numericUserId, GetWatchesParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Watch>> GetUserWatchesAsync(object numericUserId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
