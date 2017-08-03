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
        public AddNumericCustomFieldParams(IdOrKey projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.Numeric, name)
        {
        }

        public decimal Min { set => AddNewParamValue(value); }

        public decimal Max { set => AddNewParamValue(value); }

        public decimal InitialValue { set => AddNewParamValue(value); }

        public string Unit { set => AddNewParamValue(value); }
    }
}
