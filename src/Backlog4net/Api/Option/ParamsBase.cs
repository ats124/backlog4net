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

        protected void AddNewParam(string name, object value)
        {
            string strValue;
            switch (value)
            {
                case string s:
                    strValue = s;
                    break;
                case bool b:
                    strValue = b ? "true" : "false";
                    break;
                case null:
                    strValue = "";
                    break;
                default:
                    strValue = value.ToString();
                    break;
            }
            Parameters.Add(new NameValuePair(name, strValue));
        }

        protected void AddNewArrayStringParams(string name, IEnumerable<string> values, bool isEmptySetBlank = false)
        {
            if (values != null && values.Any())
            {
                foreach (var val in values) AddNewParam(name, val);
            }
            else
            {
                if (isEmptySetBlank) AddNewParam(name, "");
            }
        }

        protected void AddNewArrayParams<T>(string name, IEnumerable<T> values, Func<T, string> convFunc = null, bool isEmptySetBlank = false)
        {
            if (values != null || values.Any())
            {
                foreach (var val in values) AddNewParam(name, convFunc != null ? convFunc(val) : Convert.ToString(val));
            }
            else
            {
                if (isEmptySetBlank) AddNewParam(name, "");
            }
        }

        protected void AddNewParamValue(string value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") 
            => AddNewParam(GetDefaultParamName(memberName), value);

        protected void AddNewParamValue(object value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
            => AddNewParam(GetDefaultParamName(memberName), value);

        protected void AddNewArrayStringParamValues(IEnumerable<string> values, bool isEmptySetBlank = false, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            var name = GetDefaultArrayParamName(memberName);
            if (values != null && values.Any())
            {
                foreach (var val in values) AddNewParam(name, val);
            }
            if (values != null && values.Any())
            {
                if (isEmptySetBlank) AddNewParam(name, "");
            }
        }

        protected void AddNewArrayParamValues<T>(IEnumerable<T> values, Func<T, string> convFunc = null, bool isEmptySetBlank = false, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            var name = GetDefaultArrayParamName(memberName);
            if (values != null && values.Any())
            {
                foreach (var val in values) AddNewParam(name, convFunc != null ? convFunc(val) : Convert.ToString(val));
            }
            else
            {
                if (isEmptySetBlank) AddNewParam(name, "");
            }
        }

        private string GetDefaultParamName(string memberName)
        {
            var sb = new StringBuilder(memberName, memberName.Length);
            sb[0] = char.ToLowerInvariant(sb[0]);
            return sb.ToString();
        }

        private string GetDefaultArrayParamName(string memberName)
        {
            var sb = new StringBuilder(memberName, memberName.Length + 2);
            sb[0] = char.ToLowerInvariant(sb[0]);
            sb.Append("[]");
            return sb.ToString();
        }

        protected static string ToDateString(DateTime? date)
            => date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
    }
}
