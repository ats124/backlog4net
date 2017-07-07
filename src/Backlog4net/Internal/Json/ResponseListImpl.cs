using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Internal.Json
{
    public class ResponseListImpl<T> : List<T>, ResponseList<T>
    {
        public ResponseListImpl() { }

        public ResponseListImpl(IEnumerable<T> collection) : base(collection) {}

        public ResponseListImpl(int capacity) : base(capacity) { }

    }
}
