using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    internal static class Extensions
    {
        public static string ToStartLower(this string @this)
        {
            if (string.IsNullOrEmpty(@this)) return @this;
            var sb = new StringBuilder(@this, @this.Length);
            sb[0] = char.ToLowerInvariant(sb[0]);
            return sb.ToString();
        }

        private static readonly string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        public static bool IsImageName(string name) => 
            string.IsNullOrEmpty(name) && imageExtensions.Any(x => string.Equals(x, name, StringComparison.OrdinalIgnoreCase));
    }
}
