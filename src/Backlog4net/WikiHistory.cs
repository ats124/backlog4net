using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog Wiki page history data.
    /// </summary>
    public interface WikiHistory
    {
        long PageId { get; }

        int Version { get; }

        string Name { get; }

        string Content { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }
    }
}
