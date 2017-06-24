using System;
using System.IO;
namespace Backlog4net
{
	/// <summary>
	/// The interface for Backlog icon data.
	/// </summary>
	public interface Icon
    {
        string Filename { get; }

        Stream Content { get; }
    }
}
