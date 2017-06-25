using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog viewed issue data.
    /// </summary>
    public interface ViewedIssue
    {
        Issue Issue { get; }

        DateTime Updated { get; }
    }
}