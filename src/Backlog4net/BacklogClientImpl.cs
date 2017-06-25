using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;

namespace Backlog4net
{
    using Auth;
    using Conf;
    using Http;

    partial class BacklogClientImpl : BacklogClient
    {
        protected BacklogHttpClient HttpClient { get; private set; }
        protected BacklogConfigure Configure { get; private set; }
        protected OAuthSupport OAuthSupport { get; private set; }
        protected BacklogEndPointSupport BacklogEndPointSupport { get; private set; }

        public BacklogClientImpl(BacklogConfigure configure)
        {
            this.Configure = configure;
            this.HttpClient = new BacklogHttpClient();
            this.BacklogEndPointSupport = new BacklogEndPointSupport(configure);
            ConfigureHttpClient();
        }

        public void SetOAuthSupport(OAuthSupport oAuthSupport)
        {
            this.OAuthSupport = oAuthSupport;
        }

        protected string BuildEndpoint(string connection) => this.Configure.RestBaseUrl + (string.IsNullOrEmpty(connection) ? "" : "/" + connection);

        protected async Task<HttpResponseMessage> Get(string endpoint, ICollection<KeyValuePair<string, string>> getParams = null, CancellationToken? token = null)
        {
            var response = await HttpClient.Get(endpoint, getParams, null, token);
            if (NeedTokenRefresh(response))
            {
                RefreshToken();
                response = await HttpClient.Get(endpoint, getParams, null, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Post(string endpoint, ICollection<KeyValuePair<string, string>> postParams = null, CancellationToken? token = null)
        {
            var response = await HttpClient.Post(endpoint, postParams, token);
            if (NeedTokenRefresh(response))
            {
                RefreshToken();
                response = await HttpClient.Post(endpoint, postParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Patch(string endpoint, ICollection<KeyValuePair<string, string>> patchParams, CancellationToken? token = null)
        {
            var response = await HttpClient.Patch(endpoint, patchParams, token);
            if (NeedTokenRefresh(response))
            {
                RefreshToken();
                response = await HttpClient.Patch(endpoint, patchParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Put(string endpoint, ICollection<KeyValuePair<string, string>> putParams, CancellationToken? token = null)
        {
            var response = await HttpClient.Put(endpoint, putParams, token);
            if (NeedTokenRefresh(response))
            {
                RefreshToken();
                response = await HttpClient.Put(endpoint, putParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Delete(string endpoint, ICollection<KeyValuePair<string, string>> deleteParams = null, CancellationToken? token = null)
        {
            var response = await HttpClient.Put(endpoint, deleteParams, token);
            if (NeedTokenRefresh(response))
            {
                RefreshToken();
                response = await HttpClient.Put(endpoint, deleteParams, token);
            }
            await CheckError(response);
            return response;
        }

        private void ConfigureHttpClient()
        {
            if (Configure.ApiKey != null)
            {
                HttpClient.ApiKey = Configure.ApiKey;
            }
            else if (Configure.AccessToken != null)
            {
                HttpClient.BearerToken = Configure.AccessToken.Token;
            }
            else
            {
                throw new BacklogApiException("ApiKey or AccessToken must not be null");
            }
            HttpClient.Timeout = Configure.Timeout;
        }

        private bool NeedTokenRefresh(HttpResponseMessage response)
        {
            return (response.StatusCode == HttpStatusCode.Unauthorized ||
                    response.StatusCode == 0) && // for android bug
                    Configure.ApiKey == null &&
                    Configure.AccessToken != null;
        }

        private void RefreshToken()
        {
            var accessToken = OAuthSupport.RefreshOAuthAccessToken();
            Configure.AccessToken = accessToken;
            ConfigureHttpClient();
        }

        private static async Task CheckError(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted &&
                response.StatusCode != HttpStatusCode.NonAuthoritativeInformation &&
                response.StatusCode != HttpStatusCode.NoContent)
            {
                var mes = await response.Content.ReadAsStringAsync();
                var apiError = BacklogApiError.Decode(mes);
                throw new BacklogApiException("backlog api request failed.", (int)response.StatusCode, apiError);
            }
        }
    }
}
