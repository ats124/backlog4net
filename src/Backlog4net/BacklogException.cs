using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    /// <summary>
    /// Exception thrown when a api response contains error.
    /// </summary>
    public class BacklogException : Exception
    {
        public BacklogException() { }
        public BacklogException(string message) : base(message) { }
        public BacklogException(string message, Exception inner) : base(message, inner) { }
    }
}
