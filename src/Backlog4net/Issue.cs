using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog issue data.
    /// </summary>
    public interface Issue
    {
		long Id { get; }

		string IdAsString { get; }

        string IssueKey { get; }

        long KeyId { get; }

        string KeyIdAsString { get; }

        long ProjectId { get; }

        string ProjectIdAsString { get; }

        IssueType IssueType { get; }

        string Summary { get; }

        string Description { get; }

        Resolution Resolution { get; }

        Priority Priority { get; }

        Status Status { get; }

        User Assignee { get; }

        Category[] Category { get; }

        Version[] Versions { get; }

        Milestone[] MileStone { get; }

        DateTime StartDate { get; }

        DateTime DueDate { get; }

        Decimal EstimateHours { get; }

        Decimal ActualHours { get; }

        long ParentIssueId { get; }

        User CreatedUser { get; }

        DateTime UpdatedUser { get; }

        DateTime Updated { get; }

        CustomField[] CustomFields { get; }

        Attachment[] Attachments { get; }

        SharedFile[] SharedFiles { get; }

        Star[] Starts { get; }
    }

    public enum StatusType
    {
        Open = 1,
        InProgress = 2,
        Resolved = 3,
        Closed = 4,
    }

    public enum ResolutionType
    {
        NotSet = -1,
        FIxed = 0,
        WontFix = 1,
        Invalid = 2,
        Dupulication = 3,
        CannnotReproduce = 4,
    }

    public enum PriorityType
    {
        High = 2,
        Normal = 3,
        Low = 4,
    }
}
