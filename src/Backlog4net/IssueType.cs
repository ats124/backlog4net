using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue type data.
    /// </summary>
    public interface IssueType
    {
        long Id { get; }

        string IdAsString { get; }

        long ProjectId { get; }

        string ProjectIdAsString { get; }

        string Name { get; }

        string Color { get; }
    }
}
