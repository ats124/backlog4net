using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog Wiki page's tag data.
    /// </summary>
    public interface WikiTag
    {
        long Id { get; }

        string Name { get; }
    }
}
