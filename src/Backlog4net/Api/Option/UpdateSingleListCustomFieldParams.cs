using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateSingleListCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateSingleListCustomFieldParams(IdOrKey projectIdOrKey, long customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }

        public IList<string> Items { set => AddNewArrayStringParamValues(value, isEmptySetBlank: true); }

        public bool AllowInput { set => AddNewParamValue(value); }

        public bool AllowAddItem { set => AddNewParamValue(value); }
    }
}
