using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    using Internal.Json.CustomFields;

    public class UpdateDateCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateDateCustomFieldParams(object projectIdOrKey, object customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }

        public string Min { set => AddNewParamValue(value); }

        public string Max { set => AddNewParamValue(value); }

        public DateCustomFieldInitialValueType InitialValueType { set => AddNewParamValue(value.ToString("D")); }

        public string InitialDate { set => AddNewParamValue(value); }

        public int InitialShift { set => AddNewParamValue(value); }
    }
}
