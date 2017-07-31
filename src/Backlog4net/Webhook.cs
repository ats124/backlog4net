using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog webhook data.
    /// </summary>
    public interface Webhook
    {
        long Id { get; }

        string Name { get; }

        string Description { get; }

        string HookUrl { get; }

        bool IsAllEvent { get; }

        ActivityType[] ActivityTypeIds { get; }

        User CreatedUser { get; }

        DateTime? Created { get; }

        User UpdatedUser { get; }

        DateTime? Updated { get; }
    }
}
