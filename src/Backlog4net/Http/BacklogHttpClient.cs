using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;

namespace Backlog4net.Http
{
    using Api.Option;

    public class BacklogHttpClient
    {
        /// <summary>
        /// 事前に<see cref="CancellationToken"/>があればそれを使って、なければ新たに<see cref="CancellationTokenSource"/>をもとにトークンを作る
        /// </summary>
        class CancellationTokenHelper : IDisposable
        {
            private CancellationTokenSource csc;
            private CancellationToken token;

            public CancellationTokenHelper(CancellationToken? orgToken, TimeSpan timeout)
            {
                if (orgToken.HasValue)
                {
                    this.csc = null;
                    this.token = orgToken.Value;
                }
                else
                {
                    this.csc = new CancellationTokenSource(timeout);
                    this.token = this.csc.Token;
                }
            }

            public CancellationToken Token => csc != null ? csc.Token : token;

            public void Dispose()
            {
                if (this.csc != null)
                {
                    this.csc.Dispose();
                    this.csc = null;
                }
            }
        }

        protected static readonly HttpClient HttpClient = new HttpClient() { Timeout = System.Threading.Timeout.InfiniteTimeSpan }; // CancellationTokenでタイムアウトを指定するので

        public string ApiKey { get; set; }
        public string BearerToken { get; set; }
        public TimeSpan Timeout { get; set; }

        public async Task<HttpResponseMessage> Get(string endpoint, GetParams getParams, QueryParams queryParams, CancellationToken? token = null)
        {
            try
            {
                bool paramExists;
                var url = new StringBuilder(GetUrl(endpoint, out paramExists));
                SetParamString(url, paramExists, (getParams?.Parameters ?? new NameValuePair[0]).Concat(queryParams?.Parameters ?? new NameValuePair[0]));

                using (var request = CreateRequestMessage(HttpMethod.Get, url.ToString()))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Post(string endpoint, ICollection<NameValuePair> postParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(postParams.AsKeyValuePairs()))
                using (var request = CreateRequestMessage(HttpMethod.Post, url, content))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Patch(string endpoint, ICollection<NameValuePair> patchParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(patchParams.AsKeyValuePairs()))
                using (var request = CreateRequestMessage(new HttpMethod("PATCH"), url, content))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Put(string endpoint, ICollection<NameValuePair> putParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(putParams.AsKeyValuePairs()))
                using (var request = CreateRequestMessage(HttpMethod.Put, url, content))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Delete(string endpoint, NameValuePair deleteParam, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                var forms = deleteParam != null
                    ? new[] { deleteParam }.AsKeyValuePairs()
                    : new KeyValuePair<string, string>[0];
                using (var content = new FormUrlEncodedContent(forms))
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), url) { Content = content })
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> PostMultiPart(string endpoint, ICollection<KeyValuePair<string, object>> postParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new MultipartFormDataContent())
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    foreach (var param in postParams)
                    {
                        if (param.Value is string strValue)
                        {
                            content.Add(new StringContent(strValue), param.Key);
                        }
                        else if (param.Value is AttachmentData attach)
                        {
                            content.Add(new StreamContent(attach.Content), param.Key, attach.FileName);
                        }
                        else
                        {
                            throw new BacklogApiException($"Illegal parameter type name={param.Key},value={param.Value}");
                        }
                    }
                    return await HttpClient.PostAsync(url, content, tokenHelper.Token);
                }
            }
            catch (BacklogException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        private string GetUrl(string endpoint, out bool paramExists)
        {
            if (ApiKey == null)
            {
                paramExists = false;
                return endpoint;
            }
            else
            {
                paramExists = true;
                return $"{endpoint}?apiKey={ApiKey}";
            }
        }

        private static void SetParamString(StringBuilder sb, bool paramExists, IEnumerable<NameValuePair> getParams)
        {
            if (getParams == null || !getParams.Any()) return;
            if (!paramExists) sb.Append("?");

            foreach (var param in getParams)
            {
                if (sb.Length > 0 && sb[sb.Length - 1] != '?') sb.Append("&");
                sb.Append(WebUtility.UrlEncode(param.Name)).Append("=").Append(WebUtility.UrlEncode(param.Value));                
            }
        }

        private HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (ApiKey == null && BearerToken != null)
                request.Properties["Authorization"] = $"Bearer {BearerToken}";
            if (content != null)
                request.Content = content;
            return request;
        }
    }
}
