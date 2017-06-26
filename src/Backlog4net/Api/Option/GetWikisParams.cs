using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetWikisParams : GetParams
    {
        public GetWikisParams(object projectIdOrKey)
        {
            AddNewParam("projectIdOrKey", projectIdOrKey);
        }

        public GetWikisSortKey Sort { set => AddNewParamValue(value.ToString().ToStartLower()); }

        public Order Order { set => AddNewParamValue(value.ToString().ToStartLower()); }
    }

    public enum GetWikisSortKey
    {
        Name,
        Created,
        Updated,
    }
}
