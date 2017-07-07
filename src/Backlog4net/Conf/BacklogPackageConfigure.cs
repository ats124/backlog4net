using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Conf
{
    public class BacklogPackageConfigure : BacklogConfigure
    {
        private readonly string url;

        public BacklogPackageConfigure(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            this.url = url.EndsWith("/")
                ? url.Substring(0, url.Length - 1)
                : url;
        }

        public override string OAuthAuthorizationUrl => this.url + "/OAuth2AccessRequest.action";

        public override string OAuthAccessTokenUrl => this.url + "/api/v2/oauth2/token";

        public override string RestBaseUrl => this.url + "/api/v2";

        public override string WebAppBaseUrl => this.url;
    }
}
