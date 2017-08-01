using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Api.Option;

    partial class BacklogClientImpl
    {
        public async Task<ResponseList<Webhook>> GetWebhooksAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/webhooks"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWebhookListAsync(response);
            }
        }

        public async Task<Webhook> CreateWebhookAsync(CreateWebhookParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Post(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/webhooks"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWebhookAsync(response);
            }
        }

        public async Task<Webhook> GetWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Get(BuildEndpoint($"projects/{projectIdOrKey}/webhooks/{webhookId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWebhookAsync(response);
            }
        }

        public async Task<Webhook> UpdateWebhookAsync(UpdateWebhookParams @params, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Patch(BuildEndpoint($"projects/{@params.ProjectIdOrKey}/webhooks/{@params.WebhookId}"), @params, token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWebhookAsync(response);
            }
        }

        public async Task<Webhook> DeleteWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = default(CancellationToken?))
        {
            using (var response = await Delete(BuildEndpoint($"projects/{projectIdOrKey}/webhooks/{webhookId}"), token: token))
            using (var content = response.Content)
            {
                return await Factory.CreateWebhookAsync(response);
            }
        }
    }
}
