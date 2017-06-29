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
        public Task<ResponseList<Attachment>> AddWikiAttachmentAsync(AddWikiAttachmentParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> CreateWikiAsync(CreateWikiParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> DeleteWikiAsync(object wikiId, bool mailNotify, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> DeleteWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentData> DownloadWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> GetWikiAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Attachment>> GetWikiAttachmentsAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<int> GetWikiCountAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<WikiHistory>> GetWikiHistoriesAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<WikiHistory>> GetWikiHistoriesAsync(object wikiId, QueryParams queryParams, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Wiki>> GetWikisAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Wiki>> GetWikisAsync(GetWikisParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> GetWikiSharedFilesAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Star>> GetWikiStarsAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<WikiTag>> GetWikiTagsAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<SharedFile>> LinkWikiSharedFileAsync(object wikiId, object[] fileIds, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<SharedFile> UnlinkWikiSharedFileAsync(object wikiId, object fileId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> UpdateWikiAsync(UpdateWikiParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
