using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog viewed wiki data.
    /// </summary>
    public interface ViewedWiki
    {
        Wiki Page { get; }

        DateTime Updated { get; }
    }
}
