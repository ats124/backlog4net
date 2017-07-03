using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog Watch data.
    /// </summary>
    public interface Watch
    {
        long Id { get; }

        string IdAsString { get; }

        bool AlreadyRead { get; }

        string AlreadyReadAsString { get; }

        string Note { get; }

        string Type { get; }

        Issue Issue { get; }

        DateTime? Created { get; }

        DateTime? Updated { get; }
    }
}
