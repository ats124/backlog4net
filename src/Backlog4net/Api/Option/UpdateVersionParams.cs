using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateVersionParams : PatchParams
    {
        public UpdateVersionParams(IdOrKey projectIdOrKey, long versionId, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.VersionId = versionId;
            AddNewParam("name", name);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public long VersionId { get; private set; }

        public string Description { set => AddNewParamValue(value); }

        public DateTime? StartDate { set => AddNewParamValue(ToDateString(value)); }

        public DateTime? ReleaseDueDate { set => AddNewParamValue(ToDateString(value)); }

        public bool Archived { set => AddNewParamValue(value); }
    }
}
