using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetStarsParams : GetParams
    {
        public string Since { set => AddNewParamValue(value); }

        public string Until { set => AddNewParamValue(value); }
    }
}
