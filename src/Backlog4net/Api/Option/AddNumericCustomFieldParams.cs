using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add date type custom field API.
    /// </summary>
    public class AddNumericCustomFieldParams : AddCustomFieldParams
    {
        public AddNumericCustomFieldParams(object projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.Numeric, name)
        {
        }

        public float Min { set => AddNewParamValue(value); }

        public float Max { set => AddNewParamValue(value); }

        public float InitialValue { set => AddNewParamValue(value); }

        public string Unit { set => AddNewParamValue(value); }
    }
}
