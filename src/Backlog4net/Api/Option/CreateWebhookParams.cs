using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateWebhookParams : PostParams
    {
        public CreateWebhookParams(IdOrKey projectIdOrKey, string name, string hookUrl)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("name", name ?? "");
            AddNewParam("hookUrl", hookUrl ?? "");
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public string Description { set => AddNewParamValue(value); }

        public bool AllEvent { set => AddNewParamValue(value); }

        public IList<ActivityType> ActivityTypeIds { set => AddNewArrayParamValues(value, x => x.ToString("D")); }
    }
}
