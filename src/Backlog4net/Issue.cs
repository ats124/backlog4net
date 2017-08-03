using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue data.
    /// </summary>
    public interface Issue
    {
		long Id { get; }

        string IssueKey { get; }

        long KeyId { get; }

        long ProjectId { get; }

        IssueType IssueType { get; }

        string Summary { get; }

        string Description { get; }

        Resolution Resolution { get; }

        Priority Priority { get; }

        Status Status { get; }

        User Assignee { get; }

        Category[] Category { get; }

        Version[] Versions { get; }

        Milestone[] Milestone { get; }

        DateTime? StartDate { get; }

        DateTime? DueDate { get; }

        decimal? EstimatedHours { get; }

        decimal? ActualHours { get; }

        long? ParentIssueId { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }

        CustomField[] CustomFields { get; }

        Attachment[] Attachments { get; }

        SharedFile[] SharedFiles { get; }

        Star[] Stars { get; }
    }

    public enum IssueStatusType
    {
        Open = 1,
        InProgress = 2,
        Resolved = 3,
        Closed = 4,
    }

    public enum IssueResolutionType
    {
        //NotSet = -1, Nullableで表現
        Fixed = 0,
        WontFix = 1,
        Invalid = 2,
        Duplication = 3,
        CannotReproduce = 4,
    }

    public enum IssuePriorityType
    {
        High = 2,
        Normal = 3,
        Low = 4,
    }
}
