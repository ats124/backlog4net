using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetWikiTagsParams : GetParams
    {
        public GetWikiTagsParams(IdOrKey projectIdOrKey)
        {
            AddNewParam("projectIdOrKey", projectIdOrKey);
        }
    }
}
