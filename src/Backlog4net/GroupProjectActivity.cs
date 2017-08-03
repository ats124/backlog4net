using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog group project activity data.
    /// </summary>
    public interface GroupProjectActivity
    {
        long Id { get; }

        ActivityType Type { get; }
    }
}
