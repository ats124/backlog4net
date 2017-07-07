using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Webhook APIs.
    /// </summary>
    public interface WebhookMethods
    {
        /// <summary>
        /// Returns all the webhooks.
        /// </summary>
        /// <param name="projectIdOrKey">the project key</param>
        /// <returns>the webhooks in a list.</returns>
        Task<ResponseList<Webhook>> GetWebhooksAsync(object projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Create a webhook.
        /// </summary>
        /// <param name="params">the creating webhook parameters.</param>
        /// <returns>the created webhook</returns>
        Task<Webhook> CreateWebhookAsync(CreateWebhookParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the webhook.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="webhookId">the webhook identifier</param>
        /// <returns>the Webhook</returns>
        Task<Webhook> GetWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing webhook.
        /// </summary>
        /// <param name="params">the updating webhook parameters</param>
        /// <returns>the updated Webhook</returns>
        Task<Webhook> UpdateWebhookAsync(UpdateWebhookParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the existing webhook.
        /// </summary>
        /// <param name="projectIdOrKey">the project key</param>
        /// <param name="webhookId">the webhook identifier</param>
        /// <returns>the deleted webhook</returns>
        Task<Webhook> DeleteWebhookAsync(object projectIdOrKey, object webhookId, CancellationToken? token = null);
    }
}
