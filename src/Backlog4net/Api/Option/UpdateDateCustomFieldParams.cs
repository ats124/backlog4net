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

        public string Min { set => AddNewParamValue(value); }

        public string Max { set => AddNewParamValue(value); }
    }
}
