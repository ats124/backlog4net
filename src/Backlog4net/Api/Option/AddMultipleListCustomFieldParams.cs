using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add multiple list type custom field API.
    /// </summary>
    public class AddMultipleListCustomFieldParams : AddCustomFieldParams
    {
        public AddMultipleListCustomFieldParams(object projectIdOrKey, CustomFieldType fieldType, string name) 
            : base(projectIdOrKey, CustomFieldType.MultipleList, name)
        {
        }

        public IList<string> Items { set => AddNewArrayParamStringValues(value); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
