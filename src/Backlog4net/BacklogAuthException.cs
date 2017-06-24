using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Exception thrown when a auth api response contains error.
    /// </summary>
    public class BacklogAuthException : BacklogException
    {
        public BacklogAuthException() { }
        public BacklogAuthException(string message) : base(message)
        {
            Decode(message);
        }
        public BacklogAuthException(string message, Exception inner, int statusCode) : base(message, inner)
        {
            Decode(message);
            this.StatusCode = statusCode;
        }

        public BacklogAuthErrorMessage BacklogAuthErrorMessage { get; private set; }

        public int StatusCode { get; private set; }

        public override string Message
        {
            get
            {
                var strBuilder = new StringBuilder(base.Message);
                if (StatusCode > 0)
                {
                    strBuilder.AppendLine().AppendFormat("status code - {0]", StatusCode);
                }
                if (BacklogAuthErrorMessage != null)
                {
                    strBuilder
                        .AppendLine()
                        .Append("message - ").Append(BacklogAuthErrorMessage.Error).AppendLine()
                        .Append("description - ").Append(BacklogAuthErrorMessage.Description).AppendLine();
                }
                return strBuilder.ToString();
            }
        }

        protected void Decode(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.StartsWith("{"))
                this.BacklogAuthErrorMessage = JsonConvert.DeserializeObject<BacklogAuthErrorMessage>(str);
        }
    }
}
