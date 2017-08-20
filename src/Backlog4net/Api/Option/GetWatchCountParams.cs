using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetWatchCountParams : GetParams
    {
        public bool AlreadyRead { set => AddNewParamValue(value); }

        public bool ResourceAlreadyRead { set => AddNewParamValue(value); }
    }
}
