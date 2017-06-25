using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for activities query.
    /// </summary>
    public class ActivityQueryParams : QueryParams
    {
        public IList<ActivityType> ActivityType { set => AddNewArrayParamValues(value, x => x.ToString("D"), "activityTypeId"); }
    }
}
