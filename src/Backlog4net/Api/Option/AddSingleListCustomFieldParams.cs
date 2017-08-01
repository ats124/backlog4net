using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddSingleListCustomFieldParams : AddCustomFieldParams
    {
        public AddSingleListCustomFieldParams(IdOrKey projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.SingleList, name)
        {
        }

        public IList<string> Items { set => AddNewArrayStringParamValues(value); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
