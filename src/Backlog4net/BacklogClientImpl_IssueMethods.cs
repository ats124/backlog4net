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
        public async Task<IssueComment> AddIssueCommentAsync(AddIssueCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"issues/{@params.IssueIdOrKeyString}/comments"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueCommentAsync(response);
            }
        }

        public async Task<IssueComment> AddIssueCommentNotificationAsync(AddIssueCommentNotificationParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"issues/{@params.IssueIdOrKeyString}/comments/{@params.CommentId}/notifications"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueCommentAsync(response);
            }
        }

        public async Task<Issue> CreateIssueAsync(CreateIssueParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint("issues"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueAsync(response);
            }
        }

        public async Task<Issue> DeleteIssueAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"issues/{issueIdOrKey}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueAsync(response);
            }
        }

        public async Task<Attachment> DeleteIssueAttachmentAsync(object issueIdOrKey, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"issues/{issueIdOrKey}/attachments/{attachmentId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentAsync(response);
            }
        }

        public async Task<AttachmentData> DownloadIssueAttachmentAsync(object issueIdOrKey, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.IssueAttachmentEndpoint(issueIdOrKey, attachmentId));
            return await Internal.File.AttachmentDataImpl.CreateaAsync(response);
        }

        public async Task<Issue> GetIssueAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueAsync(response);
            }
        }

        public async Task<ResponseList<Attachment>> GetIssueAttachmentsAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<IssueComment> GetIssueCommentAsync(object issueIdOrKey, object commentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIssueCommentCountAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Notification>> GetIssueCommentNotificationsAsync(object issueIdOrKey, object commentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<IssueComment>> GetIssueCommentsAsync(object issueIdOrkey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<IssueComment>> GetIssueCommentsAsync(object issueIdOrkey, QueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Issue>> GetIssuesAsync(GetIssuesParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIssuesCountAsync(GetIssuesCountParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> GetIssueSharedFilesAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> LinkIssueSharedFileAsync(object issueIdOrKey, object[] fileIds, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SharedFile> UnlinkIssueSharedFileAsync(object issueIdOrKey, object fileId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Issue> UpdateIssueAsync(UpdateIssueParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<IssueComment> UpdateIssueCommentAsync(UpdateIssueCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
