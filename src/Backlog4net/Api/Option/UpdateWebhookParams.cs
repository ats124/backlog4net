using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWebhookParams : PatchParams
    {
        public UpdateWebhookParams(IdOrKey projectIdOrKey, long webhookId)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.WebhookId = webhookId;
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public long WebhookId { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public string HookUrl { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool AllEvent { set => AddNewParamValue(value); }

        public IList<ActivityType> ActivityTypeIds { set => AddNewArrayParamValues(value, x => x.ToString("D")); }
    }
}
