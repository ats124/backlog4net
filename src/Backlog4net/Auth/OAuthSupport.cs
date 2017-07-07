using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Auth
{
    public interface OAuthSupport
    {
        void SetOAuthClientId(string clientId, string clientSecret);
        void SetOAuthRedirectUrl(string redirectUrl);
        string GetOAuthAuthorizationUrl();
        Task<AccessToken> GetOAuthAccessTokenAsync(string oauthCode, CancellationToken? token = null);
        Task<AccessToken> RefreshOAuthAccessTokenAsync(CancellationToken? token = null);
        event EventHandler<AccessToken> OnAccessTokenRefresh;
    }
}
