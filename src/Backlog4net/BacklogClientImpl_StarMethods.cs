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
        public async Task AddStarToIssueAsync(object issueId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("issueId", issueId.ToString()) };
            using (var response = await Post("stars", @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToCommentAsync(object commentId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("commentId", commentId.ToString()) };
            using (var response = await Post("stars", @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToWikiAsync(object wikiId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("wikiId", wikiId.ToString()) };
            using (var response = await Post("stars", @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToPullRequestAsync(object pullRequestId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("pullRequestId", pullRequestId.ToString()) };
            using (var response = await Post("stars", @params, token))
            {
                response.Content.Dispose();
            }
        }

        public async Task AddStarToPullRequestCommentAsync(object pullRequestCommentId, CancellationToken? token = default(CancellationToken?))
        {
            var @params = new[] { new NameValuePair("pullRequestCommentId", pullRequestCommentId.ToString()) };
            using (var response = await Post("stars", @params, token))
            {
                response.Content.Dispose();
            }
        }
    }
}
