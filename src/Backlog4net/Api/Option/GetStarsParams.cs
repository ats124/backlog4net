using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetStarsParams : GetParams
    {
        public DateTime Since { set => AddNewParamValue(ToDateString(value)); }

        public DateTime Until { set => AddNewParamValue(ToDateString(value)); }
    }
}
