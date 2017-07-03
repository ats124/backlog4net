using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog version data.
    /// </summary>
    public interface Version
    {
        long Id { get; }

        string IdAsString { get; }

        long ProjectId { get; }

        string ProjectIdAsString { get; }

        string Name { get; }

        string Description { get; }

        DateTime? StartDate { get; }

        DateTime? ReleaseDueDate { get; }

        bool Archived { get; }
    }
}
