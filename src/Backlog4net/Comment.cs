using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog comment data.
    /// </summary>
    public interface Comment
    {
        long Id { get; }

        string Content { get; }
    }
}
