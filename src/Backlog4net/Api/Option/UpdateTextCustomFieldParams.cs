using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateTextCustomFieldParams : UpdateCustomFieldParams
    {
        public UpdateTextCustomFieldParams(IdOrKey projectIdOrKey, long customFiledId)
            : base(projectIdOrKey, customFiledId)
        {
        }
    }
}
