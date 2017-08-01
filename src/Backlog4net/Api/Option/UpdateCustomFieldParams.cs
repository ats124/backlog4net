using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateCustomFieldParams : PatchParams
    {
        public UpdateCustomFieldParams(IdOrKey projectIdOrKey, long customFiledId)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.CustomFiledId = customFiledId;
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public long CustomFiledId { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public IList<long> ApplicableIssueTypes { set => AddNewArrayParamValues(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool Required { set => AddNewParamValue(value); }
    }
}
