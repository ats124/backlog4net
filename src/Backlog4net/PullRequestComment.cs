using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog pullrequest comment data.
    /// </summary>
    public interface PullRequestComment
    {
        long Id { get; }

        string IdAsString { get; }

        string Content { get; }

        ChangeLog[] ChangeLog { get; }

        User CreatedUser { get; }

        DateTime Created { get; }

        DateTime Updated { get; }

        Star[] Stars { get; }

        Notification[] Notifications { get; }
    }
}
