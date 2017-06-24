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
    public class BacklogHttpClient
    {
        /// <summary>
        /// 事前に<see cref="CancellationToken"/>があればそれを使って、なければ新たに<see cref="CancellationTokenSource"/>をもとにトークンを作る
        /// </summary>
        class CancellationTokenHelper : IDisposable
        {
            private CancellationTokenSource csc;
            private CancellationToken token;

            public CancellationTokenHelper(CancellationToken? orgToken, int timeout)
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

        protected static readonly HttpClient HttpClient = new HttpClient();

        public string ApiKey { get; set; }
        public string BearerToken { get; set; }
        public int Timeout { get; set; }

        public async Task<HttpResponseMessage> Get(string endpoint, ICollection<KeyValuePair<string, string>> getParams, ICollection<KeyValuePair<string, string>> queryParams, CancellationToken? token = null)
        {
            bool paramExists;
            var sb = new StringBuilder(GetUrl(endpoint, out paramExists));
            SetParamString(sb, paramExists, (getParams ?? new KeyValuePair<string, string>[0]).Concat(queryParams ?? new KeyValuePair<string, string>[0]));

            try
            {
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.GetAsync(sb.ToString(), HttpCompletionOption.ResponseContentRead, tokenHelper.Token);
                }
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Post(string endpoint, ICollection<KeyValuePair<string, string>> postParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(postParams))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.PostAsync(url, content, tokenHelper.Token);
                }
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Patch(string endpoint, ICollection<KeyValuePair<string, string>> patchParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(patchParams))
                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content })
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, tokenHelper.Token);
                }
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Put(string endpoint, ICollection<KeyValuePair<string, string>> putParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(putParams))
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.PutAsync(url, content, tokenHelper.Token);
                }
            }
            catch (Exception ex)
            {
                throw new BacklogApiException("backlog api request failed.", ex);
            }
        }

        public async Task<HttpResponseMessage> Delete(string endpoint, ICollection<KeyValuePair<string, string>> deleteParams, CancellationToken? token = null)
        {
            var url = GetUrl(endpoint, out var _);
            try
            {
                using (var content = new FormUrlEncodedContent(deleteParams))
                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content })
                using (var tokenHelper = new CancellationTokenHelper(token, Timeout))
                {
                    return await HttpClient.SendAsync(request, tokenHelper.Token);
                }
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

        private static void SetParamString(StringBuilder sb, bool paramExists, IEnumerable<KeyValuePair<string, string>> getParams)
        {
            if (getParams == null || !getParams.Any()) return;
            if (sb.Length == 0 || sb[sb.Length - 1] != '?') sb.Append("?");

            foreach (var param in getParams)
            {
                if (sb.Length > 0 && sb[sb.Length - 1] != '?') sb.Append("&");
                sb.Append(WebUtility.UrlEncode(param.Key)).Append("=").Append(WebUtility.UrlEncode(param.Value));                
            }
        }
    }
}
