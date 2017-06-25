using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog voewed project data.
    /// </summary>
    public interface ViewedProject
    {
        Project Project { get; }

        DateTime Updated { get; }
    }
}
