using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateRadioCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateRadioCustomFieldParams(object projectIdOrKey, object customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }

        public IList<string> Items { set => AddNewArrayStringParamValues(value, isEmptySetBlank: true); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
