using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog link data.
    /// </summary>
    public interface Link
    {
        long Id { get; }

        string IdAsString { get; }

        long KeyId { get; }

        String KeyIdAsString { get; }

        string Title { get; }
    }
}
