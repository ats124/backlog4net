using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWatchParams : PatchParams
    {
        private object watchingId;

        public UpdateWatchParams(object watchingId)
        {
            this.watchingId = watchingId;
        }

        public string WatchingIdString => watchingId.ToString();

        public string Note { set => AddNewParamValue(value); }
    }
}
