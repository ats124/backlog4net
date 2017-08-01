using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateGroupParams : PatchParams
    {
        public UpdateGroupParams(long groupId) 
        {
            this.GroupId = groupId;
        }

        public long GroupId { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public IList<long> Members { set => AddNewArrayParamValues(value); }
    }
}
