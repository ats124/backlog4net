using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWebhookParams : PatchParams
    {
        private object projectIdOrKey;
        private object webhookId;

        public UpdateWebhookParams(object projectIdOrKey, long webhookId)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.webhookId = webhookId;
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string WebhookId => webhookId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public string HookUrl { set => AddNewParamValue(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool AllEvent { set => AddNewParamValue(value); }

        public IList<ActivityType> ActivityTypeIds { set => AddNewArrayParamValues(value, x => x.ToString("D")); }
    }
}
