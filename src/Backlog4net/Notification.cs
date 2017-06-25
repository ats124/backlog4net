using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog notification data.
    /// </summary>
    public interface Notification
    {
        long Id { get; }

        string IdAsString { get; }

        bool AlreadyRead { get; }

        Reason Reason { get; }

        bool ResourceAlreadyRead { get; }

        User Sender { get; }

        User User { get; }

        Project Project { get; }

        Issue Issue { get; }

        IssueComment Comment { get; }

        PullRequest PullRequest { get; }

        PullRequestComment PullRequestComment { get; }

        DateTime Created { get; }

    }

    public enum Reason
    {
        Undefined = -1,
        Assigned = 1,
        Commented = 2,
        IssueCreated = 3,
        IssueUpdated = 4,
        FileAttached = 5,
        ProjectUserAdded = 6,
        Other = 9,
        PullRequestAssigned = 10,
        PullRequestCommented = 11,
        PullRequestAdded = 12,
        PullRequestUpdated = 13,
    }
}
