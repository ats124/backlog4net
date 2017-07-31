using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog priority data.
    /// </summary>
    public interface Priority
    {
        long Id { get; }

        string Name { get; }

        IssuePriorityType PriorityType { get; }
    }
}
