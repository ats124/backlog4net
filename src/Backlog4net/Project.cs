using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog project data.
    /// </summary>
    public interface Project
    {
        long Id { get; }

        string IdAsString { get; }

        string ProjectKey { get; }

        string Name { get; }

        bool IsChartEnabled { get; }

        bool IsSubtaskingEnabled { get; }

        TextFormattingRule TextFormattingRule { get; }

        [JsonProperty("archived")]
        bool IsArchived { get; }

        long DisplayOrder { get; }
    }

    public enum TextFormattingRule
    {
        Markdown,
        Backlog,
    }
}
