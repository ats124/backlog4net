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

        string ProjectKey { get; }

        string Name { get; }

        bool IsChartEnabled { get; }

        bool IsSubtaskingEnabled { get; }

        TextFormattingRule TextFormattingRule { get; }

        bool IsArchived { get; }

        long DisplayOrder { get; }
    }

    public enum TextFormattingRule
    {
        Markdown,
        Backlog,
    }

    public static class IssueTypeColors
    {
        public const string Color1 = "#e30000";
        public const string Color2 = "#990000";
        public const string Color3 = "#934981";
        public const string Color4 = "#814fbc";
        public const string Color5 = "#2779ca";
        public const string Color6 = "#007e9a";
        public const string Color7 = "#7ea800";
        public const string Color8 = "#ff9200";
        public const string Color9 = "#ff3265";
        public const string Color10 = "#666665";
    }
}
