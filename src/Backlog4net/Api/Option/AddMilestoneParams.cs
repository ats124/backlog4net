using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add version API.
    /// </summary>
    public class AddMilestoneParams : PostParams
    {
        private object projectIdOrKey;

        public AddMilestoneParams(object projectIdOrKey, string name)
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
