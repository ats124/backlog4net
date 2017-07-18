using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateVersionParams : PatchParams
    {
        private object projectIdOrKey;
        private object versionId;

        public UpdateVersionParams(object projectIdOrKey, object versionId, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.versionId = versionId;
            AddNewParam("name", name);
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string VersionId => versionId.ToString();

        public string Description { set => AddNewParamValue(value); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? ReleaseDueDate { set => AddNewParamValue(ToDateString(value)); }

        public bool Archived { set => AddNewParamValue(value); }
    }
}
