using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Conf;

    public class BacklogEndPointSupport
    {
        protected BacklogConfigure Configure { get; private set; }

        public BacklogEndPointSupport(BacklogConfigure configure)
        {
            this.Configure = configure;
        }

        /// <summary>
        /// the endpoint of space icon.
        /// </summary>
        public string SpaceIconEndpoint => BuildEndpoint("space/image");

        /// <summary>
        /// the endpoint of project icon.
        /// </summary>
        public string ProjectIconEndpoint(object projectIdOrKey) => BuildEndpoint($"projects/{projectIdOrKey}/image");

        /// <summary>
        /// the endpoint of user icon.
        /// </summary>
        public string UserIconEndpoint(object numericUserId) => BuildEndpoint($"users/{numericUserId}/icon");

        /// <summary>
        /// the endpoint of shared file.
        /// </summary>
        public string SharedFileEndpoint(object projectIdOrKey, object sharedFileId) => BuildEndpoint($"projects/{projectIdOrKey}/files/{sharedFileId}");

        /// <summary>
        /// the endpoint of attachment file.
        /// </summary>
        public string IssueAttachmentEndpoint(object issueIdOrKey, object attachmentId) => BuildEndpoint($"issues/{issueIdOrKey}/attachments/{attachmentId}");

        /// <summary>
        /// endpoint of Wiki page's attachment file.
        /// </summary>
        public string WikiAttachmentEndpoint(object wikiId, object attachmentId) => BuildEndpoint($"wikis/{wikiId}/attachments/{attachmentId}");

        /// <summary>
        /// the endpoint of attachment file.
        /// </summary>
        public string PullRequestAttachmentEndpoint(object projectIdOrKey, object repoIdOrName, object number, object attachmentId)
            => BuildEndpoint($"projects/{projectIdOrKey}/git/repositories/{repoIdOrName}/pullRequests/{number}/attachments/{attachmentId}");

        protected virtual string BuildEndpoint(string connection) => Configure.RestBaseUrl + "/" + connection;
    }
}
