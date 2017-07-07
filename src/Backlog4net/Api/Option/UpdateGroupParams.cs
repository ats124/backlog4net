using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateGroupParams : PatchParams
    {
        private object groupId;

        public UpdateGroupParams(object groupId) 
        {
            this.groupId = groupId;
        }

        public string GroupId => groupId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public IList<object> Members { set => AddNewArrayParamValues(value); }
    }
}
