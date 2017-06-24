using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog shared file.
    /// </summary>
    public interface SharedFile
    {
        long Id { get; }

        string IdAsString { get; }

        string Type { get; }

        string Name { get; }

        string Dir { get; }

        long Size { get; }

        User CreatedUser { get; }

        DateTime Created { get; }

        User UpdatedUser { get; }

        DateTime Updated { get; }

        bool IsImage { get; }
    }
}
