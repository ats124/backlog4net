using System;
using System.Collections.Generic;

namespace Backlog4net
{
    /// <summary>
    /// The interface for response list.
    /// </summary>
    public interface ResponseList<T> : IList<T>
    {
        void Sort(Comparison<T> comparison);
    }
}