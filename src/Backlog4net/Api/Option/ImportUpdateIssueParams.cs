﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class ImportUpdateIssueParams : UpdateIssueParams
    {
        public ImportUpdateIssueParams(IdOrKey issueIdOrKey) : base(issueIdOrKey) { }

        public long CreatedUserId { set => AddNewParamValue(value); }

        public DateTime Created { set => AddNewParamValue(ToDateTimeString(value)); }

        public long UpdatedUserId { set => AddNewParamValue(value); }

        public DateTime Updated { set => AddNewParamValue(ToDateTimeString(value)); }
    }
}
