using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog file data.
    /// </summary>
    public interface FileData : IDisposable
    {
        string FileName { get; }
        Stream Content { get; }
    }
}
