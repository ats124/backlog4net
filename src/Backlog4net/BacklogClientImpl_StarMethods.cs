using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;
    using Http;

    partial class BacklogClientImpl
    {
        public async Task AddStarToIssueAsync(long issueId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("issueId", issueId.ToString()) };
            using (var response = await Post(BuildEndpoint("stars"), @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToCommentAsync(long commentId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("commentId", commentId.ToString()) };
            using (var response = await Post(BuildEndpoint("stars"), @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToWikiAsync(long wikiId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("wikiId", wikiId.ToString()) };
            using (var response = await Post(BuildEndpoint("stars"), @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToPullRequestAsync(long pullRequestId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("pullRequestId", pullRequestId.ToString()) };
            using (var response = await Post(BuildEndpoint("stars"), @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToPullRequestCommentAsync(long pullRequestCommentId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("pullRequestCommentId", pullRequestCommentId.ToString()) };
            using (var response = await Post(BuildEndpoint("stars"), @params, token))
            {
                response.Content.Dispose();
            }
        }
    }
}
