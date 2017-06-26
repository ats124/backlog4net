using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetRepositoriesParams : GetParams
    {
        public GetRepositoriesParams(long projectId)
        {
            AddNewParam("projectIdOrKey", projectId);
        }
        public GetRepositoriesParams(string projectKey)
        {
            AddNewParam("projectIdOrKey", projectKey);
        }
    }
}
