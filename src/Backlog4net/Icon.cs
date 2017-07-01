using System;
using System.IO;
namespace Backlog4net
{
	/// <summary>
	/// The interface for Backlog icon data.
	/// </summary>
	public interface Icon : IDisposable
    {
        string FileName { get; }

        Stream Content { get; }
    }
}
