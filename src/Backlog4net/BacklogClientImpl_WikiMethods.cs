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
    using Internal.File;
    using Http;

    partial class BacklogClientImpl
    {
        public Task<ResponseList<Wiki>> GetWikisAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
            => GetWikisAsync(new GetWikisParams(projectIdOrKey), token);

        public async Task<ResponseList<Wiki>> GetWikisAsync(GetWikisParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("wikis"), @params, token: token))
            using (var content = response.Content)
            {                
                var list = await Factory.CreateWikiListAsync(response);
                list.Sort((x, y) =>
                {
                    switch (@params.Sort)
                    {
                        case GetWikisSortKey.Name:
                            return @params.Order == Order.Asc
                                ? string.Compare(x.Name, y.Name)
                                : string.Compare(y.Name, x.Name);
                        case GetWikisSortKey.Created:
                            return @params.Order == Order.Asc
                                ? DateTime.Compare(x.Created ?? DateTime.MinValue, y.Created ?? DateTime.MinValue)
                                : DateTime.Compare(y.Created ?? DateTime.MinValue, x.Created ?? DateTime.MinValue);
                        case GetWikisSortKey.Updated:
                            return @params.Order == Order.Asc
                                ? DateTime.Compare(x.Updated ?? DateTime.MinValue, y.Updated ?? DateTime.MinValue)
                                : DateTime.Compare(y.Updated ?? DateTime.MinValue, x.Updated ?? DateTime.MinValue);
                        default:
                            return 0;
                    }                    
                });
                return list;
            }
        }

        public async Task<int> GetWikiCountAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("wikis/count"), new GetWikisParams(projectIdOrKey), token: token))
            using (var content = response.Content)
            {
                return (await Factory.CreateCountAsync(response)).CountValue;
            }
        }

        public async Task<ResponseList<WikiTag>> GetWikiTagsAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint("wikis/tags"), new GetWikisParams(projectIdOrKey), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiTagListAsync(response);
            }
        }

        public async Task<Wiki> CreateWikiAsync(CreateWikiParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint("wikis"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiAsync(response);
            }
        }

        public async Task<Wiki> GetWikiAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"wikis/{wikiId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiAsync(response);
            }
        }

        public async Task<Wiki> UpdateWikiAsync(UpdateWikiParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"wikis/{@params.WikiId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiAsync(response);
            }
        }

        public async Task<Wiki> DeleteWikiAsync(object wikiId, bool mailNotify, CancellationToken? token = default(CancellationToken?))
        {
            var param = new NameValuePair("mailNotify", mailNotify.ToString());
            using (var response = await Delete(BuildEndpoint($"wikis/{wikiId}"), param, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiAsync(response);
            }
        }

        public async Task<ResponseList<Attachment>> GetWikiAttachmentsAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"wikis/{wikiId}/attachments"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentListAsync(response);
            }
        }

        public async Task<ResponseList<Attachment>> AddWikiAttachmentAsync(AddWikiAttachmentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"wikis/{@params.WikiId}/attachments"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentListAsync(response);
            }
        }

        public async Task<AttachmentData> DownloadWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            var response = await Get(BacklogEndPointSupport.WikiAttachmentEndpoint(wikiId, attachmentId));
            return await AttachmentDataImpl.CreateaAsync(response);
        }

        public async Task<Attachment> DeleteWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"wikis/{wikiId}/attachments/{attachmentId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateAttachmentAsync(response);
            }
        }

        public async Task<ResponseList<SharedFile>> GetWikiSharedFilesAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"wikis/{wikiId}/sharedFiles"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateSharedFileListAsync(response);
            }
        }

        public async Task<ResponseList<SharedFile>> LinkWikiSharedFileAsync(object wikiId, object[] fileIds, CancellationToken? token = default(CancellationToken?))
        {
            var @params = fileIds.Select(x => new NameValuePair("fileId[]", x.ToString())).ToArray();
            using (var response = await Post(BuildEndpoint($"wikis/{wikiId}/sharedFiles"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateSharedFileListAsync(response);
            }
        }

        public async Task<SharedFile> UnlinkWikiSharedFileAsync(object wikiId, object fileId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"wikis/{wikiId}/sharedFiles/{fileId}"), token: token))
            using (var content = response.Content)
            {
               return await Factory.CreateSharedFileAsync(response);
            }
        }

        public async Task<ResponseList<WikiHistory>> GetWikiHistoriesAsync(object wikiId, QueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"wikis/{wikiId}/history"), queryParams, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWikiHistoryListAsync(response);
            }
        }

        public async Task<ResponseList<Star>> GetWikiStarsAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"wikis/{wikiId}/stars"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateStarListAsync(response);
            }
        }
    }
}
