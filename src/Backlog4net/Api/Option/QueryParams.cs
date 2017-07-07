using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    using Http;

    public class QueryParams : GetParams
    {
        public object MinId { set => AddNewParamValue(value); }

        public object MaxId { set => AddNewParamValue(value); }

        public int Count { set => AddNewParamValue(value); }

        public Order Order { set => AddNewParamValue(value.ToString().ToLower()); }
    }
}
