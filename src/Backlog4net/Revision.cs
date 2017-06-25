using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog revision data.
    /// </summary>
    public interface Revision
    {
        string Rev { get; }

        string Comment { get; }
    }
}
