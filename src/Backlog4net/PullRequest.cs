using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog pullrequest data.
    /// </summary>
    public interface PullRequest
    {
        long Id { get; }

        string IdAsString { get; }

        long ProjectId { get; }

        string ProjectIdAsString { get; }

        long RepositoryId { get; }

        string RepositoryIdAsString { get; }

        long Number { get; }

        string Summary { get; }

        string Description { get; }

        string Base { get; }

        string Branch { get; }

        PullRequestStatus Status { get; }

        User Assignee { get; }

        Issue Issue { get; }

        string MergeCommit { get; }

        string BaseCommit { get; }

        string BranchCommit { get; }

        string CloseAt { get; }

        string MergeAt { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }

        Attachment[] Attachments { get; }

        Star[] Stars { get; }

    }

	public enum PullRequestStatusType
	{
		Open = 1,
		Closed = 2,
		Merged = 3,
	}
}
