using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog file data.
    /// </summary>
    public interface FileData
    {
        string FileName { get; }
        Stream Content { get; }
    }
}
