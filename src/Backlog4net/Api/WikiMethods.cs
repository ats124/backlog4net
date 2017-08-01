using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Wiki APIs.
    /// </summary>
    public interface WikiMethods
    {
        /// <summary>
        /// Returns Wiki pages in the project.
        /// </summary>
        /// <param name="projectIdOrKey">projectIdOrKey</param>
        /// <returns>the Wiki pages in a list</returns>
        Task<ResponseList<Wiki>> GetWikisAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns Wiki pages in the project.
        /// </summary>
        /// <param name="params">the finding wiki parameters</param>
        /// <returns>the Wiki pages in a list</returns>
        Task<ResponseList<Wiki>> GetWikisAsync(GetWikisParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns Wiki pages count.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Wiki pages count</returns>
        Task<int> GetWikiCountAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns Wiki page's tags in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Wiki page's tags in a list</returns>
        Task<ResponseList<WikiTag>> GetWikiTagsAsync(IdOrKey projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Create a Wiki page in the project.
        /// </summary>
        /// <param name="params">the creating Wiki page parameters</param>
        /// <returns>the created Wiki page</returns>
        Task<Wiki> CreateWikiAsync(CreateWikiParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page</returns>
        Task<Wiki> GetWikiAsync(object wikiId, CancellationToken? token = null);

        /// <summary>
        /// Updates an existing Wiki page in the project.
        /// </summary>
        /// <param name="params">the updating Wiki page parameters</param>
        /// <returns>the updated Wiki page</returns>
        Task<Wiki> UpdateWikiAsync(UpdateWikiParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="mailNotify">mailNotify</param>
        /// <returns>the deleted Wiki page</returns>
        Task<Wiki> DeleteWikiAsync(object wikiId, bool mailNotify, CancellationToken? token = null);

        /// <summary>
        /// Returns the Wiki page's attachment files.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page identifier</returns>
        Task<ResponseList<Attachment>> GetWikiAttachmentsAsync(object wikiId, CancellationToken? token = null);

        /// <summary>
        /// Attaches the files to the Wiki page.
        /// </summary>
        /// <param name="params">the Wiki page's attachment parameters</param>
        /// <returns>the added Wiki page's attachment file</returns>
        Task<ResponseList<Attachment>> AddWikiAttachmentAsync(AddWikiAttachmentParams @params, CancellationToken? token = null);

        /// <summary>
        /// Downloads the Wiki page's attachment file.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="attachmentId">the attachment file identifier</param>
        /// <returns>downloaded file data</returns>
        Task<AttachmentData> DownloadWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = null);

        /// <summary>
        /// Deletes the Wiki page's attachment file
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="attachmentId">the attachment file identifier</param>
        /// <returns>deleted Wiki page's attachment file</returns>
        Task<Attachment> DeleteWikiAttachmentAsync(object wikiId, object attachmentId, CancellationToken? token = null);

        /// <summary>
        /// Returns the Wiki page's shared files.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page's shared files in a list</returns>
        Task<ResponseList<SharedFile>> GetWikiSharedFilesAsync(object wikiId, CancellationToken? token = null);

        /// <summary>
        /// Links the shared files to Wiki.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="fileIds">the shared file identifiers</param>
        /// <returns>the linked shared files</returns>
        Task<ResponseList<SharedFile>> LinkWikiSharedFileAsync(object wikiId, object[] fileIds, CancellationToken? token = null);

        /// <summary>
        /// Removes link to shared Files from the Wiki.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="fileId">the shared file identifier</param>
        /// <returns>the removed link shared file</returns>
        Task<SharedFile> UnlinkWikiSharedFileAsync(object wikiId, object fileId, CancellationToken? token = null);

        /// <summary>
        /// Returns history of the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the wiki histories in a list</returns>
        Task<ResponseList<WikiHistory>> GetWikiHistoriesAsync(object wikiId, QueryParams queryParams = null, CancellationToken? token = null);

        /// <summary>
        /// Returns list of stars received on the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the wiki stars in a list</returns>
        Task<ResponseList<Star>> GetWikiStarsAsync(object wikiId, CancellationToken? token = null);
    }
}
