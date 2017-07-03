using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog group data.
    /// </summary>
    public interface Group
    {
        long Id { get; }

        string IdAsString { get; }

        string Name { get; }

        User[] Members { get; }

        long DisplayOrder { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }
    }
}
