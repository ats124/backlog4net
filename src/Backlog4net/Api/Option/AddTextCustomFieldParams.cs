using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddTextCustomFieldParams : AddCustomFieldParams
    {
        public AddTextCustomFieldParams(IdOrKey projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.Text, name)
        {
        }
    }
}
