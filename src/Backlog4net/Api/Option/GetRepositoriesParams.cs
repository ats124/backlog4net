using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetRepositoriesParams : GetParams
    {
        public GetRepositoriesParams(IdOrKey projectIdOrKey)
        {
            AddNewParam("projectIdOrKey", projectIdOrKey);
        }
    }
}
