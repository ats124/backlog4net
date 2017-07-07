using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Auth
{
    using Conf;
    using Http;
    using Internal;
    using Internal.Json;
    using System.Net;

    public class BacklogOAuthSupport : OAuthSupport
    {
        private string clientId;
        private string clientSecret;
        private string redirectUrl;

        private BacklogConfigure configure;
        private BacklogHttpClient httpClient;
        private InternalFactory factory = new InternalFactoryJsonImpl();

        public event EventHandler<AccessToken> OnAccessTokenRefresh;

        public BacklogOAuthSupport(BacklogConfigure configur)
        {
            this.configure = configur;
            this.httpClient = new BacklogHttpClient();
            this.httpClient.Timeout = configur.Timeout;
        }

        public async Task<AccessToken> GetOAuthAccessTokenAsync(string oauthCode, CancellationToken? token = null)
        {
            var @params = new[]
            {
                new NameValuePair("code", oauthCode),
                new NameValuePair("client_id", clientId),
                new NameValuePair("client_secret", clientSecret),
                new NameValuePair("redirect_uri", redirectUrl),
                new NameValuePair("grant_type", "authorization_code"),
            };

            var resMes = await httpClient.Post(configure.OAuthAccessTokenUrl, @params, token);
            await CheckError(resMes);
            return await factory.CreateAccessTokenAsync(resMes);
        }

        public string GetOAuthAuthorizationUrl()
            => $"{configure.OAuthAuthorizationUrl}?client_id={clientId}&response_type=code{(!string.IsNullOrEmpty(redirectUrl) ? "&redirect_uri=" + WebUtility.UrlEncode(this.redirectUrl) : "")}";

        public async Task<AccessToken> RefreshOAuthAccessTokenAsync(CancellationToken? token = null)
        {
            var @params = new[]
            {
                new NameValuePair("client_id", clientId),
                new NameValuePair("client_secret", clientSecret),
                new NameValuePair("refresh_token", configure.AccessToken.Refresh),
                new NameValuePair("grant_type", "refresh_token"),
            };

            var resMes = await httpClient.Post(configure.OAuthAccessTokenUrl, @params, token);
            await CheckError(resMes);
            var accessToken = await factory.CreateAccessTokenAsync(resMes);
            configure.AccessToken = accessToken;
            if (OnAccessTokenRefresh != null) OnAccessTokenRefresh(this, accessToken);
            return accessToken;
        }

        public void SetOAuthClientId(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        public void SetOAuthRedirectUrl(string redirectUrl)
        {
            this.redirectUrl = redirectUrl;
        }
        private async Task CheckError(HttpResponseMessage resMes)
        {
            if (resMes.StatusCode != HttpStatusCode.OK && resMes.StatusCode != HttpStatusCode.Created)
            {
                var content = await resMes.Content.ReadAsStringAsync();
                var error = BacklogAuthErrorMessage.Decode(content);
                throw new BacklogAuthException("backlog oauth request failed.", (int)resMes.StatusCode, error);
            }
        }
    }
}
