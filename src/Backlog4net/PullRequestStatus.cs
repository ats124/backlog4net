using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog pullrequest status data.
    /// </summary>
    public interface PullRequestStatus
    {
        int Id { get; }

        string Name { get; }

        PullRequestStatusType Status { get; }
    }
}
