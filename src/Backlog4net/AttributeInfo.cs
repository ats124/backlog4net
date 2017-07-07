using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    public interface AttributeInfo
    {
        long Id { get; }

        string IdAsString { get; }

        string Type { get; }
    }
}
