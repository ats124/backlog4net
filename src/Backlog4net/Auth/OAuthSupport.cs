using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Auth
{
    public interface OAuthSupport
    {
        void SetOAuthClientId(string clientId, string clientSecret);
        void SetOAuthRedirectUrl(string redirectUrl);
        string GetOAuthAuthorizationURL();
        AccessToken GetOAuthAccessToken(string oauthCode);
        AccessToken RefreshOAuthAccessToken();
        event EventHandler<AccessToken> OnAccessTokenRefresh;
    }
}
