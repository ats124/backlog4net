using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog attachment file.
    /// </summary>
    public interface PostedAttachment
    {
        long Id { get; }

        string IdAsString { get; }

        string Name { get; }

        long Size { get; }
    }
}
