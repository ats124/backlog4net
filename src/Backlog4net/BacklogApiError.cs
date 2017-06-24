using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    /// <summary>
    /// The error class for Backlog exception.
    /// Contains the error massages.
    /// </summary>
    public class BacklogApiError
    {
        public BacklogApiErrorMessage[] Errors { get; private set; }
    }
}