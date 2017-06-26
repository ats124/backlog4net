using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateWebhookParams : PostParams
    {
        private object projectIdOrKey;

        public CreateWebhookParams(object projectIdOrKey, string name, string hookUrl)
        {
            this.projectIdOrKey = projectIdOrKey;
            AddNewParam("name", name ?? "");
            AddNewParam("hookUrl", hookUrl ?? "");
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string Description { set => AddNewParamValue(value); }

        public bool AllEvent { set => AddNewParamValue(value); }

        public IList<ActivityType> ActivityTypeIds { set => AddNewArrayParamValues(value, x => x.ToString("D")); }
    }
}
