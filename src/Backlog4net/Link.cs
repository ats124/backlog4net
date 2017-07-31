using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog link data.
    /// </summary>
    public interface Link
    {
        long Id { get; }

        long KeyId { get; }

        string Title { get; }
    }
}
