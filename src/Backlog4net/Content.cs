using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog content data.
    /// </summary>
    public interface Content
    {
    }

    public interface UndefinedContent : Content
    {
    }

    public interface FileAddedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Dir { get; }

        long Size { get; }
    }

    public interface FileDeletedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Dir { get; }

        long Size { get; }
    }

    public interface FileUpdatedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Dir { get; }

        long Size { get; }
    }

    public interface GitPushedContent : Content
    {
       string ChangeType { get; }

       string Ref { get; }

       string RevisionType { get; }

       Repository Repository { get; }

       IList<Revision> Revisions { get; }

       long RevisionCount { get; }
    }

    public interface GitRepositoryCreatedContent : Content
    {
        Repository Repository { get; }
    }

    public interface IssueCommentedContent : Content
    {
        long Id { get; }

        long KeyId { get; }

        string Summary { get; }

        string Description { get; }

        Comment Comment { get; }

        IList<Change> Changes { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface IssueCreatedContent : Content
    {
        long Id { get; }

        long KeyId { get; }

        string Summary { get; }

        string Description { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface IssueDeletedContent : Content
    {
        long Id { get; }

        long KeyId { get; }
    }

    public interface IssueMultiUpdatedContent : Content
    {
        long TxId { get; }

        Comment Comment { get; }

        IList<Link> Link { get; }

        IList<Change> Changes { get; }
    }

    public interface IssueUpdatedContent : Content
    {
        long Id { get; }

        long KeyId { get; }

        string Summary { get; }

        string Description { get; }

        Comment Comment { get; }

        IList<Change> Changes { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface NotificationAddedContent : Content
    {
        long Id { get; }

        long KeyId { get; }

        string Summary { get; }

        string Description { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface ProjectUserAddedContent : Content
    {
        IList<User> Users { get; }

        string Comment { get; }

        IList<GroupProjectActivity> GroupProjectActivities { get; }
    }

    public interface ProjectUserRemovedContent : Content
    {
        IList<User> Users { get; }

        string Comment { get; }

        IList<GroupProjectActivity> GroupProjectActivities { get; }
    }

    public interface PullRequestContent : Content
    {
        long Id { get; }

        long Number { get; }

        string Summary { get; }

        string Description { get; }

        Comment Comment { get; }

        IList<Change> Changes { get; }

        Repository Repository { get; }
    }

    public interface SvnCommittedContent : Content
    {
        string Comment { get; }

        long Rev { get; }
    }

    public interface WikiCreatedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Content { get; }

        string Diff { get; }

        int? Version { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface WikiDeletedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Content { get; }

        string Diff { get; }

        int? Version { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface WikiUpdatedContent : Content
    {
        long Id { get; }

        string Name { get; }

        string Content { get; }

        string Diff { get; }

        int? Version { get; }

        IList<Attachment> Attachments { get; }

        IList<SharedFile> SharedFiles { get; }
    }

    public interface MilestoneCreatedContent : Content
    {
        long Id { get; }

        string Name { get; }

        DateTime? StartDate { get; }

        DateTime? ReferenceDate { get; }

        string Description { get; }
    }

    public interface MilestoneUpdatedContent : Content
    {
        long Id { get; }

        string Name { get; }

        IList<Change> Changes { get; }
    }


    public interface MilestoneDeletedContent : Content
    {
        long Id { get; }

        string Name { get; }

        DateTime? StartDate { get; }

        DateTime? ReferenceDate { get; }

        string Description { get; }
    }
}
