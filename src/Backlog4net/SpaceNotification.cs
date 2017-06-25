using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog space notification data.
    /// </summary>
    public interface SpaceNotification
    {
        string content { get; }

        DateTime Updated { get; }
    }
}
