using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog Wiki page data.
    /// </summary>
    public interface Wiki
    {
        long Id { get; }

        string IdAsString { get; }

        long ProjectId { get; }

        string ProjectIdAsString { get; }

        string Name { get; }

        string Content { get; }

        WikiTag[] Tags { get; }

        Attachment[] Attachments { get; }

        SharedFile[] SharedFiles { get; }

        Star[] Stars { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }
    }
}