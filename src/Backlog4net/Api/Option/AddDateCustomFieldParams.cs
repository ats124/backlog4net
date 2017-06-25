using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add date type custom field API.
    /// </summary>
    public class AddDateCustomFieldParams : AddCustomFieldParams
    {
        public AddDateCustomFieldParams(object projectIdOrKey, CustomFieldType fieldType, string name) 
            : base(projectIdOrKey, CustomFieldType.Date, name)
        {
        }

        public string Min { set => AddNewParamValue(value); }

        public string Max { set => AddNewParamValue(value); }
    }
}
