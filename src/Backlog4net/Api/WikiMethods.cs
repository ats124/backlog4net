using System;
using System.Collections.Generic;
using System.Text;

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
        ResponseList<Wiki> GetWikis(object projectIdOrKey);

        /// <summary>
        /// Returns Wiki pages in the project.
        /// </summary>
        /// <param name="params">the finding wiki parameters</param>
        /// <returns>the Wiki pages in a list</returns>
        ResponseList<Wiki> GetWikis(GetWikisParams @params);

        /// <summary>
        /// Returns Wiki pages count.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Wiki pages count</returns>
        int GetWikiCount(object projectIdOrKey);

        /// <summary>
        /// Returns Wiki page's tags in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the Wiki page's tags in a list</returns>
        ResponseList<WikiTag> GetWikiTags(object projectIdOrKey);

        /// <summary>
        /// Create a Wiki page in the project.
        /// </summary>
        /// <param name="params">the creating Wiki page parameters</param>
        /// <returns>the created Wiki page</returns>
        Wiki CreateWiki(CreateWikiParams @params);

        /// <summary>
        /// Returns the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page</returns>
        Wiki GetWiki(object wikiId);

        /// <summary>
        /// Updates an existing Wiki page in the project.
        /// </summary>
        /// <param name="params">the updating Wiki page parameters</param>
        /// <returns>the updated Wiki page</returns>
        Wiki UpdateWiki(UpdateWikiParams @params);

        /// <summary>
        /// Deletes the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="mailNotify">mailNotify</param>
        /// <returns>the deleted Wiki page</returns>
        Wiki DeleteWiki(object wikiId, bool mailNotify);

        /// <summary>
        /// Returns the Wiki page's attachment files.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page identifier</returns>
        ResponseList<Attachment> GetWikiAttachments(object wikiId);

        /// <summary>
        /// Attaches the files to the Wiki page.
        /// </summary>
        /// <param name="params">the Wiki page's attachment parameters</param>
        /// <returns>the added Wiki page's attachment file</returns>
        ResponseList<Attachment> AddWikiAttachment(AddWikiAttachmentParams @params);

        /// <summary>
        /// Downloads the Wiki page's attachment file.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="attachmentId">the attachment file identifier</param>
        /// <returns>downloaded file data</returns>
        AttachmentData DownloadWikiAttachment(object wikiId, object attachmentId);

        /// <summary>
        /// Deletes the Wiki page's attachment file
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="attachmentId">the attachment file identifier</param>
        /// <returns>deleted Wiki page's attachment file</returns>
        Attachment DeleteWikiAttachment(object wikiId, object attachmentId);

        /// <summary>
        /// Returns the Wiki page's shared files.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the Wiki page's shared files in a list</returns>
        ResponseList<SharedFile> GetWikiSharedFiles(object wikiId);

        /// <summary>
        /// Links the shared files to Wiki.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="fileIds">the shared file identifiers</param>
        /// <returns>the linked shared files</returns>
        ResponseList<SharedFile> LinkWikiSharedFile(object wikiId, object[] fileIds);

        /// <summary>
        /// Removes link to shared Files from the Wiki.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="fileId">the shared file identifier</param>
        /// <returns>the removed link shared file</returns>
        SharedFile UnlinkWikiSharedFile(object wikiId, object fileId);

        /// <summary>
        /// Returns history of the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the wiki histories in a list</returns>
        ResponseList<WikiHistory> GetWikiHistories(object wikiId);

        /// <summary>
        /// Returns history of the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <param name="queryParams">the query parameters</param>
        /// <returns>the wiki histories in a list</returns>
        ResponseList<WikiHistory> GetWikiHistories(object wikiId, QueryParams queryParams);

        /// <summary>
        /// Returns list of stars received on the Wiki page.
        /// </summary>
        /// <param name="wikiId">the Wiki page identifier</param>
        /// <returns>the wiki stars in a list</returns>
        ResponseList<Star> GetWikiStars(object wikiId);
    }
}
