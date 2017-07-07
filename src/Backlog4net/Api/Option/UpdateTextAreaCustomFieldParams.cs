using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateTextAreaCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateTextAreaCustomFieldParams(object projectIdOrKey, object customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }
    }
}
