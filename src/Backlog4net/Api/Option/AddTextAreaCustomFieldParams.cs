using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddTextAreaCustomFieldParams : AddCustomFieldParams
    {
        public AddTextAreaCustomFieldParams(object projectIdOrKey, string name) 
            : base(projectIdOrKey, CustomFieldType.TextArea, name)
        {
        }
    }
}
