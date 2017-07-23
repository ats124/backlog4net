using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog change data.
    /// </summary>
    public interface Change
    {
        string Field { get; }

        string NewValue { get; }

        string OldValue { get; }

        string Type { get; }
    }
}
