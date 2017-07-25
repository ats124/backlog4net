using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog activity data.
    /// </summary>
    public interface Activity
    {
        long Id { get; }

        string IdAsString { get; }

        Project Project { get; }

        ActivityType Type { get; }

        Content Content { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }
    }

    public enum ActivityType
    {
        Undefined = -1,
        IssueCreated = 1,
        IssueUpdated = 2,
        IssueCommented = 3,
        IssueDeleted = 4,
        WikiCreated = 5,
        WikiUpdated = 6,
        WikiDeleted = 7,
        FileAdded = 8,
        FileUpdated = 9,
        FileDeleted = 10,
        SvnCommitted = 11,
        GitPushed = 12,
        GitRepositoryCreated = 13,
        IssueMultiUpdated = 14,
        ProjectUserAdded = 15,
        ProjectUserRemoved = 16,
        NotifyAdded = 17,
        PullRequestAdded = 18,
        PullRequestUpdated = 19,
        PullRequestCommented = 20,
        PullRequestMerged = 21,
    }

    public interface UndefinedActivity : Activity
    {
        new UndefinedContent Content { get; }
    }

    public interface FileAddedActivity : Activity
    {
        new FileAddedContent Content { get; }
    }

    public interface FileDeletedActivity : Activity
    {
        new FileDeletedContent Content { get; }
    }

    public interface FileUpdatedActivity : Activity
    {
        new FileUpdatedContent Content { get; }
    }

    public interface GitPushedActivity : Activity
    {
        new GitPushedContent Content { get; }
    }

    public interface GitRepositoryCreatedActivity : Activity
    {
        new GitRepositoryCreatedContent Content { get; }
    }

    public interface IssueCommentedActivity : Activity
    {
        new IssueCommentedContent Content { get; }
    }

    public interface IssueCreatedActivity : Activity
    {
        new IssueCreatedContent Content { get; }
    }

    public interface IssueDeletedActivity : Activity
    {
        new IssueDeletedContent Content { get; }
    }

    public interface IssueMultiUpdatedActivity : Activity
    {
        new IssueMultiUpdatedContent Content { get; }
    }

    public interface IssueUpdatedActivity : Activity
    {
        new IssueUpdatedContent Content { get; }
    }

    public interface NotificationAddedActivity : Activity
    {
        new NotificationAddedContent Content { get; }
    }

    public interface ProjectUserAddedActivity : Activity
    {
        new ProjectUserAddedContent Content { get; }
    }

    public interface ProjectUserRemovedActivity : Activity
    {
        new ProjectUserRemovedContent Content { get; }
    }

    public interface PullRequestAddedActivity : Activity
    {
        new PullRequestContent Content { get; }
    }

    public interface PullRequestCommentedActivity : Activity
    {
        new PullRequestContent Content { get; }
    }

    public interface PullRequestUpdatedActivity : Activity
    {
        new PullRequestContent Content { get; }
    }

    public interface SvnCommittedActivity : Activity
    {
        new SvnCommittedContent Content { get; }
    }

    public interface WikiCreatedActivity : Activity
    {
        new WikiCreatedContent Content { get; }
    }

    public interface WikiDeletedActivity : Activity
    {
        new WikiDeletedContent Content { get; }
    }

    public interface WikiUpdatedActivity : Activity
    {
        new WikiUpdatedContent Content { get; }
    }
}
