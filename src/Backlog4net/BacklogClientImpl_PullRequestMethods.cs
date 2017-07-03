using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Backlog4net.Internal.File;

    partial class BacklogClientImpl
    {
        public async Task<ResponseList<PullRequest>> GetPullRequestsAsync(object projectIdOrKey, object repoIdOrName, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestListAsync(response);
            }
        }

        public async Task<ResponseList<PullRequest>> GetPullRequestsAsync(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests");
            using (var response = await Get(url, @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestListAsync(response);
            }
        }

        public async Task<int> GetPullRequestCountAsync(object projectIdOrKey, object repoIdOrName, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/count");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<int> GetPullRequestCountAsync(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/count");
            using (var response = await Get(url, @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<PullRequest> AddPullRequestAsync(AddPullRequestParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{@params.ProjectIdOrKeyString}/git/repositories/{@params.RepoIdOrName}/pullRequests");
            using (var response = await Post(url, @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestAsync(response);
            }
        }

        public async Task<PullRequest> UpdatePullRequestAsync(UpdatePullRequestParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{@params.ProjectIdOrKeyString}/git/repositories/{@params.RepoIdOrName}/pullRequests/{@params.Number}");
            using (var response = await Patch(url, @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestAsync(response);
            }
        }

        public async Task<PullRequest> GetPullRequestAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestAsync(response);
            }
        }

        public async Task<ResponseList<PullRequestComment>> GetPullRequestCommentsAsync(object projectIdOrKey, object repoIdOrName, object number, QueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}/comments");
            using (var response = await Get(url, @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestCommentListAsync(response);
            }
        }

        public async Task<int> GetPullRequestCommentCountAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}/comments/count");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<PullRequestComment> AddPullRequestCommentAsync(AddPullRequestCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{@params.ProjectIdOrKeyString}/git/repositories/{@params.RepoIdOrName}/pullRequests/{@params.Number}/comments");
            using (var response = await Post(url, @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestCommentAsync(response);
            }
        }

        public async Task<PullRequestComment> UpdatePullRequestCommentAsync(UpdatePullRequestCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{@params.ProjectIdOrKeyString}/git/repositories/{@params.RepoIdOrName}/pullRequests/{@params.Number}/comments/{@params.CommentId}");
            using (var response = await Patch(url, @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreatePullRequestCommentAsync(response);
            }
        }

        public async Task<ResponseList<Attachment>> GetPullRequestAttachmentsAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}/attachments");
            using (var response = await Get(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentListAsync(response);
            }
        }

        public async Task<AttachmentData> DownloadPullRequestAttachmentAsync(object projectIdOrKey, object repoIdOrName, object number, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.PullRequestAttachmentEndpoint(projectIdOrKey, repoIdOrName, number, attachmentId));
            return await AttachmentDataImpl.CreateaAsync(response);
        }

        public async Task<Attachment> DeletePullRequestAttachmentAsync(object projectIdOrKey, object repoIdOrName, object number, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            var url = BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}/attachments/{attachmentId}");
            using (var response = await Delete(url, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentAsync(response);
            }
        }
    }
}
