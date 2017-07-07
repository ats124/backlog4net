using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog space data.
    /// </summary>
    public interface Space
    {
        string SpaceKey { get; }

        string Name { get; }

        long OwnerId { get; }

        string OwnerIdAsString { get; }

        string Lang { get; }

        string Timezone { get; }

        string ReportSendTime { get; }

        string TextFormattingRule { get; }

        DateTime? Created { get; }

        DateTime? Updated { get; }
    }
}
