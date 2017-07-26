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
        public AddDateCustomFieldParams(object projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.Date, name)
        {
        }

        public string Min { set => AddNewParamValue(value); }

        public string Max { set => AddNewParamValue(value); }

        public DateCustomFieldInitialValueType InitialValueType { set => AddNewParamValue(value.ToString("D")); }

        public string InitialDate { set => AddNewParamValue(value); }

        public int InitialShift { set => AddNewParamValue(value); }
    }
}
