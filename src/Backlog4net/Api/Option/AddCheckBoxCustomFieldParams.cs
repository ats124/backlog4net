using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add checkbox type custom field API.
    /// </summary>
    public class AddCheckBoxCustomFieldParams : AddCustomFieldParams
    {
        public AddCheckBoxCustomFieldParams(object projectIdOrKey, CustomFieldType fieldType, string name) 
            : base(projectIdOrKey, CustomFieldType.ChexkBox, name)
        {
        }

        public IList<string> Items { set => AddNewArrayParamStringValues(value); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
