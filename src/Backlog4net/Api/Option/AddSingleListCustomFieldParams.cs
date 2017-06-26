using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddSingleListCustomFieldParams : AddCustomFieldParams
    {
        public AddSingleListCustomFieldParams(object projectIdOrKey, CustomFieldType fieldType, string name) 
            : base(projectIdOrKey, CustomFieldType.SingleList, name)
        {
        }

        public IList<string> Items { set => AddNewArrayParamStringValues(value); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
