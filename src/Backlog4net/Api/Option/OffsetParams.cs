using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class OffsetParams : GetParams
    {
        public int Offset { set => AddNewParamValue(value); }

        public int Count { set => AddNewParamValue(value); }

        public Order Order { set => AddNewParamValue(value.ToString().ToStartLower()); }
    }
}
