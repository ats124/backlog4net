using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateTextAreaCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateTextAreaCustomFieldParams(IdOrKey projectIdOrKey, long customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }
    }
}
