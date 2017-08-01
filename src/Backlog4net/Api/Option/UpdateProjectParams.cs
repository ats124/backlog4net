using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateProjectParams : PatchParams
    {
        public UpdateProjectParams(IdOrKey projectIdOrKey)
        {
            this.ProjectIdOrKey = projectIdOrKey;
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public string ProjectKey { set => AddNewParam("key", value); }

        public bool ChartEnabled { set => AddNewParamValue(value); }

        public bool SubtaskingEnabled { set => AddNewParamValue(value); }

        public TextFormattingRule TextFormattingRule { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public bool Archived { set => AddNewParamValue(value); }
    }
}
