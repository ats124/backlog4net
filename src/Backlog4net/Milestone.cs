using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog milestone data.
    /// </summary>
    public interface Milestone
    {
        long Id { get; }

        long ProjectId { get; }

        string Name { get; }

        string Description { get; }

        DateTime? StartDate { get; }

        DateTime? ReleaseDueDate { get; }

        bool Archived { get; }
    }
}
