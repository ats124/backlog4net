using System;
using System.Collections.Generic;
using System.Text;

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
        ResponseList<Webhook> GetWebhooks(object projectIdOrKey);

        /// <summary>
        /// Create a webhook.
        /// </summary>
        /// <param name="params">the creating webhook parameters.</param>
        /// <returns>the created webhook</returns>
        Webhook CreateWebhook(CreateWebhookParams @params);

        /// <summary>
        /// Returns the webhook.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="webhookId">the webhook identifier</param>
        /// <returns>the Webhook</returns>
        Webhook GetWebhook(object projectIdOrKey, object webhookId);

        /// <summary>
        /// Updates the existing webhook.
        /// </summary>
        /// <param name="params">the updating webhook parameters</param>
        /// <returns>the updated Webhook</returns>
        Webhook UpdateWebhook(UpdateWebhookParams @params);

        /// <summary>
        /// Deletes the existing webhook.
        /// </summary>
        /// <param name="projectIdOrKey">the project key</param>
        /// <param name="webhookId">the webhook identifier</param>
        /// <returns>the deleted webhook</returns>
        Webhook DeleteWebhook(object projectIdOrKey, object webhookId);
    }
}
