using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateDateCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateDateCustomFieldParams(object projectIdOrKey, object customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }

        public DateTime? Min { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? Max { set => AddNewParamValue(ToDateString(value)); }

        public DateCustomFieldInitialValueType InitialValueType { set => AddNewParamValue(value.ToString("D")); }

        public DateTime? InitialDate { set => AddNewParamValue(ToDateString(value)); }

        public int? InitialShift { set => AddNewParamValue(value); }
    }
}
