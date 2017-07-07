using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateCustomFieldParams : PatchParams
    {
        private object projectIdOrKey;
        private object customFiledId;

        public UpdateCustomFieldParams(object projectIdOrKey, object customFiledId)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.customFiledId = customFiledId;
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string CustomFiledId => customFiledId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public IList<long> ApplicableIssueTypes { set => AddNewArrayParamValues(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool Required { set => AddNewParamValue(value); }
    }
}
