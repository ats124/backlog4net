using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    using Http;

    public abstract class ParamsBase
    {
        public IList<NameValuePair> Parameters { get; } = new List<NameValuePair>();

        protected void AddNewParam(string name, string value) => Parameters.Add(new NameValuePair(name, value));

        protected void AddNewParam(string name, object value) => Parameters.Add(new NameValuePair(name, (value ?? string.Empty).ToString()));

        protected void AddNewParamValue(string value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") 
            => Parameters.Add(new NameValuePair(GetDefaultParamName(memberName), value));

        protected void AddNewParamValue(object value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") 
            => Parameters.Add(new NameValuePair(GetDefaultParamName(memberName), (value ?? string.Empty).ToString()));

        protected void AddNewArrayParamStringValues(IEnumerable<string> values, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            if (values != null && values.Any())
            {
                var name = GetDefaultArrayParamName(memberName);
                foreach (var val in values) AddNewParam(name, val);
            }
        }

        protected void AddNewArrayParamValues<T>(IEnumerable<T> values, Func<T, string> convFunc = null, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            if (values != null && values.Any())
            {
                var name = GetDefaultArrayParamName(memberName);
                foreach (var val in values) AddNewParam(name, convFunc != null ? convFunc(val) : Convert.ToString(val));
            }
        }

        private string GetDefaultParamName(string memberName)
        {
            var sb = new StringBuilder(memberName, memberName.Length);
            sb[0] = char.ToUpperInvariant(sb[0]);
            return sb.ToString();
        }
        private string GetDefaultArrayParamName(string memberName)
        {
            var sb = new StringBuilder(memberName, memberName.Length + 2);
            sb[0] = char.ToUpperInvariant(sb[0]);
            sb.Append("[]");
            return sb.ToString();
        }
    }
}
