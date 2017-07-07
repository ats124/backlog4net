using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Conf;

    public class BacklogClientFactory
    {
        private BacklogConfigure Configure { get; }

        public BacklogClientFactory(BacklogConfigure configure)
        {
            this.Configure = configure;
        }

        public BacklogClient NewClient()
        {
            return new BacklogClientImpl(Configure);
        }
    }
}
