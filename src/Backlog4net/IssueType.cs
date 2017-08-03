using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue type data.
    /// </summary>
    public interface IssueType
    {
        long Id { get; }

        long ProjectId { get; }

        string Name { get; }

        string Color { get; }
    }
}
