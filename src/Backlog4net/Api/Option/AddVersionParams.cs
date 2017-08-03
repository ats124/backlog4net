using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddVersionParams : PostParams
    {
        public IdOrKey ProjectIdOrKey { get; private set; }

        public AddVersionParams(IdOrKey projectIdOrKey, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("name", name);
        }

        public string Description { set => AddNewParamValue(value); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? ReleaseDueDate { set => AddNewParamValue(ToDateString(value)); }
    }
}
