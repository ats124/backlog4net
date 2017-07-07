using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateGroupParams : PostParams
    {
        public CreateGroupParams(string name) 
        {
            AddNewParam("name", name);
        }

        public IList<object> Members { set => AddNewArrayParamValues(value); }
    }
}
