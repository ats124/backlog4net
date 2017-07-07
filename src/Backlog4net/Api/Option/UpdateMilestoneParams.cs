using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateMilestoneParams : PatchParams
    {
        private object projectIdOrKey;
        private object versionId;

        public UpdateMilestoneParams(object projectIdOrKey, object versionId, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.versionId = versionId;
            AddNewParam("name", name);
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string VersionId => versionId.ToString();

        public string Description { set => AddNewParamValue(value); }

        public string StartDate { set => AddNewParamValue(value); }

        public string ReleaseDueDate { set => AddNewParamValue(value); }

        public bool Archived { set => AddNewParamValue(value); }
    }
}
