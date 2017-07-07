using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue comment data.
    /// </summary>
    public interface IssueComment : Comment
    {
        ChangeLog[] ChangeLog { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        DateTime? Updated { get; }

        Star[] Stars { get; }

        Notification[] Notifications { get; }
    }
}
