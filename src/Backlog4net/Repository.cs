using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Vacklog repository data.
    /// </summary>
    public interface Repository
    {
        long Id { get; }

        long ProjectId { get; }

        string Name { get; }

        string Description { get; }

        string HookUrl { get; }

        string HttpUrl { get; }

        string SshUrl { get; }

        long DisplayOrder { get; }

        DateTime? PushedAt { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }
    }
}