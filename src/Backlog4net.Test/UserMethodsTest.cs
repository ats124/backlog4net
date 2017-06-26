using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Conf;

    [TestClass]
    public class UserMethodsTest
    {
        const string ApiKey = "Oi1TGEfTJ5WKmYiQh9gACR9uioorFryLAW8CA8BZWAkUi1qvmdCvK1UaxAg8dQQF";

        [TestMethod]
        public async Task TestGetUsers1()
        {
            var config = new BacklogJpConfigure("section-9");
            config.ApiKey = ApiKey;
            var client = new BacklogClientFactory(config).NewClient();
            var users = await client.GetUsersAsync();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }
    }
}
