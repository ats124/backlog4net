using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog resolution data.
    /// </summary>
    public interface Resolution
    {
        long Id { get; }

        string IdAsString { get; }

        string Name { get; }

        IssueResolutionType ResolutionType { get; }
    }
}
