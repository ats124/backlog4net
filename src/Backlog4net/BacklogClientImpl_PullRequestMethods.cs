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
        public Task<PullRequest> AddPullRequestAsync(AddPullRequestParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<PullRequestComment> AddPullRequestCommentAsync(AddPullRequestCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> DeletePullRequestAttachmentAsync(object projectIdOrKey, object repoIdOrName, object number, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentData> DownloadPullRequestAttachmentAsync(object projectIdOrKey, object repoIdOrName, object number, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<PullRequest> GetPullRequestAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Attachment>> GetPullRequestAttachmentsAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPullRequestCommentCountAsync(object projectIdOrKey, object repoIdOrName, object number, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<PullRequestComment>> GetPullRequestCommentsAsync(object projectIdOrKey, object repoIdOrName, object number, QueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPullRequestCountAsync(object projectIdOrKey, object repoIdOrName, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPullRequestCountAsync(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<PullRequest>> GetPullRequestsAsync(object projectIdOrKey, object repoIdOrName, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<PullRequest>> GetPullRequestsAsync(object projectIdOrKey, object repoIdOrName, PullRequestQueryParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<PullRequest> UpdatePullRequestAsync(UpdatePullRequestParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<PullRequestComment> UpdatePullRequestCommentAsync(UpdatePullRequestCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
