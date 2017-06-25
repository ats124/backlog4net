using System;
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

        private string GetDefaultParamName(string memberName)
        {
            var sb = new StringBuilder(memberName, memberName.Length);
            sb[0] = char.ToUpperInvariant(sb[0]);
            return sb.ToString();
        }
    }
}
