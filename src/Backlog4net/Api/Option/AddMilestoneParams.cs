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
        public AddMilestoneParams(IdOrKey projectIdOrKey, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("name", name);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public string Description { set => AddNewParamValue(value); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? ReleaseDueDate { set => AddNewParamValue(ToDateString(value)); }
    }
}
