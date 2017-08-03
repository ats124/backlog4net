using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWatchParams : PatchParams
    {
        public UpdateWatchParams(long watchingId)
        {
            this.WatchingId = watchingId;
        }

        public long WatchingId { get; private set; }

        public string Note { set => AddNewParamValue(value); }
    }
}
