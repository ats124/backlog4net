using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Internal.Json;
    using Internal.Json.Activities;

    [TestClass]
    public class ActivityJsonImplTest
    {
        [TestMethod]
        public void TestFileAddedActivity()
        {
            var json =
@"{
    id: 1, 
    type:8, 
    content: {
        id: 3,
        name: ""test-name.jpg"",
        dir: ""test-dir"",
        size: 1000},
    project: {
        id: 2, 
        projectKey:""test-key"",
        name: ""test-name"",
        chartEnabled: true,
        subtaskingEnabled: true, 
        textFormattingRule: ""backlog"", 
        archived: true, 
        displayOrder:99 },
    createdUser: {
        id: 3,
        name: ""test-name"",
        userId: ""test-id"",
        roleType: 3,
        lang: ""ja"",
        mailAddress: ""test-mail""},
    created: ""2008-07-06T15:00:00Z""
}";

            var obj = JsonConvert.DeserializeObject<Activity>(json, new ActivityJsonImplBase.JsonConverter());
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj is FileAddedActivity);
            var file = (FileAddedActivity)obj;
            Assert.AreEqual(file.Id, 1);
            Assert.AreEqual(file.Type, ActivityType.FileAdded);

            Assert.IsNotNull(file.Content);
            Assert.AreEqual(file.Content.Id, 3);
            Assert.AreEqual(file.Content.Name, "test-name.jpg");
            Assert.IsTrue(file.Content.IsImage);
            Assert.AreEqual(file.Content.Dir, "test-dir");
            Assert.AreEqual(file.Content.Size, 1000);

            Assert.IsNotNull(file.Project);
            Assert.AreEqual(file.Project.Id, 2);
            Assert.AreEqual(file.Project.ProjectKey, "test-key");
            Assert.AreEqual(file.Project.Name, "test-name");
            Assert.IsTrue(file.Project.IsChartEnabled);
            Assert.IsTrue(file.Project.IsSubtaskingEnabled);
            Assert.AreEqual(file.Project.TextFormattingRule, TextFormattingRule.Backlog);
            Assert.IsTrue(file.Project.IsArchived);

            Assert.IsNotNull(file.CreatedUser);
            Assert.AreEqual(file.CreatedUser.Id, 3);
            Assert.AreEqual(file.CreatedUser.Name, "test-name");
            Assert.AreEqual(file.CreatedUser.UserId, "test-id");
            Assert.AreEqual(file.CreatedUser.RoleType, UserRoleType.Reporter);
            Assert.AreEqual(file.CreatedUser.Lang, "ja");
            Assert.AreEqual(file.CreatedUser.MailAddress, "test-mail");
        }

        [TestMethod]
        public void TestUndefinedActivity()
        {
            var json =
@"{
    id: 1, 
    type:99, 
    content: {
        id: 3,
        name: ""test-name.jpg"",
        dir: ""test-dir"",
        size: 1000},
    project: {
        id: 2, 
        projectKey:""test-key"",
        name: ""test-name"",
        chartEnabled: true,
        subtaskingEnabled: true, 
        textFormattingRule: ""backlog"", 
        archived: true, 
        displayOrder:99 },
    createdUser: {
        id: 3,
        name: ""test-name"",
        userId: ""test-id"",
        roleType: 3,
        lang: ""ja"",
        mailAddress: ""test-mail""},
    created: ""2008-07-06T15:00:00Z""
}";

            var obj = JsonConvert.DeserializeObject<Activity>(json, new ActivityJsonImplBase.JsonConverter());
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj is UndefinedActivity);

        }
    }
}
