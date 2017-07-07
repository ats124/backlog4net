using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog changeLog data.
    /// </summary>
    public interface ChangeLog
    {
        long Field { get; }

        string NewValue { get; }

        string OriginalValue { get; }

        AttachmentInfo AttachmentInfo { get; }

        AttributeInfo AttributeInfo { get; }

        NotificationInfo NotificationInfo { get; }
    }
}
