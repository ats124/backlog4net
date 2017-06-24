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

        DateTime Created { get; }
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
}
