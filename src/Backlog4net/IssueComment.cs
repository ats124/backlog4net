using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue comment data.
    /// </summary>
    public interface IssueComment
    {
        ChangeLog[] ChangeLog { get; }

        User CreatedUser { get; }

        DateTime Created { get; }

        DateTime Updated { get; }

        Star[] Starts { get; }

        Notification[] Notifications { get; }
    }
}
