using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateProjectParams : PatchParams
    {
        private object projectIdOrKey;

        public UpdateProjectParams(object projectIdOrKey)
        {
            this.projectIdOrKey = projectIdOrKey;
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string Name { set => AddNewParamValue(value); }

        public string ProjectKey { set => AddNewParamValue(value); }

        public bool ChartEnabled { set => AddNewParamValue(value); }

        public bool SubtaskingEnabled { set => AddNewParamValue(value); }

        public TextFormattingRule TextFormattingRule { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public bool Archived { set => AddNewParamValue(value); }
    }
}
