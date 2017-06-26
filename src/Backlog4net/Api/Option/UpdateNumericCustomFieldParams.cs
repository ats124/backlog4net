using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateNumericCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateNumericCustomFieldParams(object projectIdOrKey, object customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }

        public float Min { set => AddNewParamValue(value); }

        public float Max { set => AddNewParamValue(value); }

        public float InitialValue { set => AddNewParamValue(value); }

        public string Unit { set => AddNewParamValue(value); }
    }
}
