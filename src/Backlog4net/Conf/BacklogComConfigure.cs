using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Conf
{
    public sealed class BacklogComConfigure : BacklogConfigure
    {
        private readonly string spaceKey;

        public BacklogComConfigure(string spaceKey)
        {
            if (spaceKey == null) throw new ArgumentNullException(nameof(spaceKey));
            this.spaceKey = spaceKey;
        }

        public override string OAuthAuthorizationUrl => $"https://{spaceKey}.backlog.com/OAuth2AccessRequest.action";

        public override string OAuthAccessTokenUrl => $"https://{spaceKey}.backlog.com/api/v2/oauth2/token";

        public override string RestBaseUrl => $"https://{spaceKey}.backlog.com/api/v2";

        public override string WebAppBaseUrl => $"https://{spaceKey}.backlog.com";
    }
}
