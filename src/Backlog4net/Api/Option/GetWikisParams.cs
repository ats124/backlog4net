using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetWikisParams : GetParams
    {
        private GetWikisSortKey sort;
        private Order order;

        public GetWikisParams(object projectIdOrKey)
        {
            AddNewParam("projectIdOrKey", projectIdOrKey);
        }

        public GetWikisSortKey Sort
        {
            set
            {
                sort = value;
                AddNewParamValue(value.ToString().ToStartLower());
            }
            get => sort;
        }

        public Order Order
        {
            set
            {
                order = value;
                AddNewParamValue(value.ToString().ToStartLower());
            }
            get => order;
        }
    }

    public enum GetWikisSortKey
    {
        Name,
        Created,
        Updated,
    }
}
