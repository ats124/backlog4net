using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetWatchesParams : QueryParams
    {
        public GetWatchsSortKey Sort { set => AddNewParamValue(value.ToString().ToLowerInvariant()); }

        public bool ResourceAlreadyRead { set => AddNewParamValue(value); }

        public IList<long> IssueIds { set => AddNewArrayParams("issueId[]", value); }
    }

    public enum GetWatchsSortKey
    {
        Created,
        Updated,
        IssueUpdated,
    }
}
