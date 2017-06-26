using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api.Option;

    [TestClass]
    public class ApiOptionsTest
    {
        [TestMethod]
        public void TestActivityQueryParams()
        {
            var param = new ActivityQueryParams()
            {
                ActivityType = new[] { ActivityType.IssueCommented, ActivityType.IssueCreated },
                Count = 10,
                MinId = 1,
                MaxId = 100,
                Order = Order.Asc,
            };

            var parameters = param.Parameters;
            Assert.IsTrue(parameters.Any(x => x.Name == "activityTypeId[]" && x.Value == "3"));
            Assert.IsTrue(parameters.Any(x => x.Name == "activityTypeId[]" && x.Value == "1"));
            Assert.IsTrue(parameters.Any(x => x.Name == "count" && x.Value == "10"));
            Assert.IsTrue(parameters.Any(x => x.Name == "minId" && x.Value == "1"));
            Assert.IsTrue(parameters.Any(x => x.Name == "maxId" && x.Value == "100"));
            Assert.IsTrue(parameters.Any(x => x.Name == "order" && x.Value == "asc"));
        }
    }
}
