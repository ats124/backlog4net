using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog category data.
    /// </summary>
    public interface Category
    {
        long Id { get; }

        string IdAsString { get; }

        string Name { get; }
    }
}
