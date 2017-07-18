using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddVersionParams : PostParams
    {
        private object projectIdOrKey;

        public AddVersionParams(object projectIdOrKey, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            AddNewParam("name", name);
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string Description { set => AddNewParamValue(value); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? ReleaseDueDate { set => AddNewParamValue(ToDateString(value)); }
    }
}
