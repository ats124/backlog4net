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
    using Api.Option;
    using Internal;
    using Internal.Json;

    partial class BacklogClientImpl : BacklogClient
    {
        protected BacklogHttpClient HttpClient { get; private set; }
        protected BacklogConfigure Configure { get; private set; }
        protected InternalFactory Factory { get; } = new InternalFactoryJsonImpl();
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

        protected async Task<HttpResponseMessage> Get(string endpoint, GetParams getParams = null, QueryParams queryParams = null, CancellationToken? token = null)
        {
            var response = await HttpClient.Get(endpoint, getParams, queryParams, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.Get(endpoint, getParams, queryParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected Task<HttpResponseMessage> Post(string endpoint, PostParams postParams = null, CancellationToken? token = null) => 
            Post(endpoint, postParams?.Parameters ?? new NameValuePair[0], token);

        protected async Task<HttpResponseMessage> Post(string endpoint, ICollection<NameValuePair> postParams, CancellationToken? token = null)
        {
            var response = await HttpClient.Post(endpoint, postParams, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.Post(endpoint, postParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected Task<HttpResponseMessage> Patch(string endpoint, PatchParams patchParams, CancellationToken? token = null) =>
            Patch(endpoint, patchParams?.Parameters ?? new NameValuePair[0], token);

        protected async Task<HttpResponseMessage> Patch(string endpoint, ICollection<NameValuePair> patchParams, CancellationToken? token = null)
        {
            var response = await HttpClient.Patch(endpoint, patchParams, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.Patch(endpoint, patchParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Put(string endpoint, ICollection<NameValuePair> putParams, CancellationToken? token = null)
        {
            var response = await HttpClient.Put(endpoint, putParams, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.Put(endpoint, putParams, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> Delete(string endpoint, NameValuePair deleteParam = null, CancellationToken? token = null)
        {
            var response = await HttpClient.Delete(endpoint, deleteParam, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.Delete(endpoint, deleteParam, token);
            }
            await CheckError(response);
            return response;
        }

        protected async Task<HttpResponseMessage> PostMultiPart(string endpoint, ICollection<KeyValuePair<string, object>> postParams, CancellationToken? token = null)
        {
            var response = await HttpClient.PostMultiPart(endpoint, postParams, token);
            if (NeedTokenRefresh(response))
            {
                await RefreshToken();
                response = await HttpClient.PostMultiPart(endpoint, postParams, token);
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

        private async Task RefreshToken(CancellationToken? token = null)
        {
            var accessToken = await OAuthSupport.RefreshOAuthAccessTokenAsync(token);
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
