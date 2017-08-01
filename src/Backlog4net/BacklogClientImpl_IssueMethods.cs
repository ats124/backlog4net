using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Backlog4net.Http;

    partial class BacklogClientImpl
    {
        public async Task<IssueComment> AddIssueCommentAsync(AddIssueCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"issues/{@params.IssueIdOrKey}/comments"), @params, token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueCommentAsync(response);
            }
        }

        public async Task<IssueComment> AddIssueCommentNotificationAsync(AddIssueCommentNotificationParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"issues/{@params.IssueIdOrKey}/comments/{@params.CommentId}/notifications"), @params, token))
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
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/attachments"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentListAsync(response);
            }
        }

        public async Task<IssueComment> GetIssueCommentAsync(object issueIdOrKey, object commentId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/comments/{commentId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateIssueCommentAsync(response);
            }
        }

        public async Task<int> GetIssueCommentCountAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/comments/count"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<Notification>> GetIssueCommentNotificationsAsync(object issueIdOrKey, object commentId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/comments/{commentId}/notifications"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateNotificationListAsync(response);
            }
        }

        public async Task<ResponseList<IssueComment>> GetIssueCommentsAsync(object issueIdOrKey, QueryParams queryParams = null, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/comments"), queryParams, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateIssueCommentListAsync(response));
            }
        }

        public async Task<ResponseList<Issue>> GetIssuesAsync(GetIssuesParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateIssueListAsync(response));
            }
        }

        public async Task<int> GetIssuesCountAsync(GetIssuesCountParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/count"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<SharedFile>> GetIssueSharedFilesAsync(object issueIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"issues/{issueIdOrKey}/sharedFiles"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateSharedFileListAsync(response));
            }
        }

        public async Task<ResponseList<SharedFile>> LinkIssueSharedFileAsync(object issueIdOrKey, object[] fileIds, CancellationToken? token = default(CancellationToken?))
        {
            var @params = fileIds.Select(x => new NameValuePair("fileId[]", x.ToString())).ToArray();
            using (var response = await Post(BuildEndpoint($"issues/{issueIdOrKey}/sharedFiles"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateSharedFileListAsync(response));
            }
        }

        public async Task<SharedFile> UnlinkIssueSharedFileAsync(object issueIdOrKey, object fileId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"issues/{issueIdOrKey}/sharedFiles/{fileId}"), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateSharedFileAsync(response));
            }
        }

        public async Task<Issue> UpdateIssueAsync(UpdateIssueParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"issues/{@params.IssueIdOrKey}"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateIssueAsync(response));
            }
        }

        public async Task<IssueComment> UpdateIssueCommentAsync(UpdateIssueCommentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"issues/{@params.IssueIdOrKey}/comments/{@params.CommentId}"), @params, token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateIssueCommentAsync(response));
            }
        }
    }
}
