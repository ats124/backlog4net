using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Http
{
    public class NameValuePair
    {
        public string Name { get; }
        public string Value { get; }
        public NameValuePair(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }

    public static class NameValuePairExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> AsKeyValuePairs(this IEnumerable<NameValuePair> @this) => 
            @this.Select(x => new KeyValuePair<string, string>(x.Name, x.Value));
    }
}
