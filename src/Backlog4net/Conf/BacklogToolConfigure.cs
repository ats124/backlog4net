using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Conf
{
    public class BacklogToolConfigure : BacklogConfigure
    {
        private readonly string spaceKey;

        public BacklogToolConfigure(string spaceKey)
        {
            if (spaceKey == null) throw new ArgumentNullException(nameof(spaceKey));
            this.spaceKey = spaceKey;
        }

        public override string OAuthAuthorizationUrl => $"https://{spaceKey}.backlogtool.com/OAuth2AccessRequest.action";

        public override string OAuthAccessTokenUrl => $"https://{spaceKey}.backlogtool.com/api/v2/oauth2/token";

        public override string RestBaseUrl => $"https://{spaceKey}.backlogtool.com/api/v2";

        public override string WebAppBaseUrl => $"https://{spaceKey}.backlogtool.com";
    }
}
