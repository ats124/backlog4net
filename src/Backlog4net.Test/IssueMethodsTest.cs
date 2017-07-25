//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Backlog4net.Test
//{
//    using Api;
//    using Api.Option;
//    using Conf;
//    using TestConfig;

//    [TestClass]
//    public class IssueMethodsTest
//    {
//        private static BacklogClient client;
//        private static GeneralConfig generalConfig;
//        private static object projectId;
//        private static IList<IssueType> issueTypes;

//        [ClassInitialize]
//        public static async Task SetupClient(TestContext context)
//        {
//            generalConfig = GeneralConfig.Instance.Value;
//            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
//            conf.ApiKey = generalConfig.ApiKey;
//            client = new BacklogClientFactory(conf).NewClient();

//            var project = await client.GetProjectAsync(generalConfig.ProjectKey);
//            projectId = project.Id;
//            issueTypes = await client.GetIssueTypesAsync(projectId);
//        }

//        [TestMethod]
//        public async Task GetIssuesCountAsync()
//        {
//            var count = await client.GetIssuesCountAsync(new GetIssuesCountParams(55947));
//            Assert.IsTrue(count > 0);
//        }

//        //[TestMethod]
//        //public async Task AddUpdateGetDeleteIssueAsync()
//        //{
//        //    var createParams = new CreateIssueParams(projectId, "summary-test", issueTypes.First(), IssuePriorityType.High)
//        //    {

//        //    };
//        //}
//    }
//}
