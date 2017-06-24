using System;
namespace Backlog4net
{
    public interface Star
    {
        long Id { get; }

        string IdAsString { get; }

        string Comment { get; }

        string Url { get; }

        string Title { get; }

        User Presenter { get; }

        DateTime Created { get; }
    }
}
