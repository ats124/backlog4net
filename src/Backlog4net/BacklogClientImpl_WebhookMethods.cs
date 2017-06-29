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
        public Task<Webhook> CreateWebhookAsync(CreateWebhookParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Webhook> DeleteWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Webhook> GetWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<ResponseList<Webhook>> GetWebhooksAsync(object projectIdOrKey, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }

        public Task<Webhook> UpdateWebhookAsync(UpdateWebhookParams @params, CancellationToken? token = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
