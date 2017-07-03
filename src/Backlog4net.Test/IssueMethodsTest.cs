using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api;
    using Api.Option;
    using Conf;
    using TestConfig;

    [TestClass]
    public class IssueMethodsTest
    {        
        private static BacklogClient client;
        private static GeneralConfig generalConfig;

        [ClassInitialize]
        public static void SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();
        }

        [TestMethod]
        public async Task GetIssuesCountAsync()
        {
            var count = await client.GetIssuesCountAsync(new GetIssuesCountParams(55947));
            Assert.IsTrue(count > 0);
        }
    }
}
