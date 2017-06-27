using System;
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
    }
}
