﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backlog4net.Test
{
    using Api;
    using Api.Option;
    using Backlog4net.Internal.Json;
    using Backlog4net.Internal.Json.Activities;
    using Conf;
    using Newtonsoft.Json;
    using TestConfig;

    [TestClass]
    public class WikiMethodsTest
    {
        private static BacklogClient client;
        private static GeneralConfig generalConfig;
        private static string projectKey;
        private static long projectId;

        [ClassInitialize]
        public static async Task SetupClient(TestContext context)
        {
            generalConfig = GeneralConfig.Instance.Value;
            var conf = new BacklogJpConfigure(generalConfig.SpaceKey);
            conf.ApiKey = generalConfig.ApiKey;
            client = new BacklogClientFactory(conf).NewClient();
            var users = await client.GetUsersAsync();

            projectKey = generalConfig.ProjectKey;
            var project = await client.GetProjectAsync(projectKey);
            projectId = project.Id;
        }

        [TestMethod]
        public async Task WikiTest()
        {
            var wiki = await client.CreateWikiAsync(new CreateWikiParams(projectId, "TestName", "TestContent")
            {
                MailNotify = false,
            });
            Assert.AreEqual(wiki.ProjectId, projectId);
            Assert.AreNotEqual(wiki.Id, 0);
            Assert.AreEqual(wiki.Name, "TestName");
            Assert.AreEqual(wiki.Content, "TestContent");

            var wikiGet = await client.GetWikiAsync(wiki.Id);
            Assert.AreEqual(wikiGet.Id, wiki.Id);
            Assert.AreEqual(wikiGet.Name, "TestName");
            Assert.AreEqual(wikiGet.Content, "TestContent");

            var wikiUpdated = await client.UpdateWikiAsync(new UpdateWikiParams(wiki.Id)
            {
                Name = "TestNameUpdated",
                Content = "TestContentUpdated",                
                MailNotify = false,
            });
            Assert.AreEqual(wikiUpdated.Id, wiki.Id);
            Assert.AreEqual(wikiUpdated.Name, "TestNameUpdated");
            Assert.AreEqual(wikiUpdated.Content, "TestContentUpdated");

            var wikiDeleted = await client.DeleteWikiAsync(wiki.Id, false);
            Assert.AreEqual(wikiDeleted.Id, wiki.Id);
            Assert.AreEqual(wikiDeleted.Name, "TestNameUpdated");
            Assert.AreEqual(wikiDeleted.Content, "TestContentUpdated");
        }

        [TestMethod]
        public async Task WikiAttachmentTestAsync()
        {
            var wikiName = $"Test({DateTime.Now:yyyy/MM/dd HH:mm:ss})";
            var wiki = await client.CreateWikiAsync(new CreateWikiParams(projectId, wikiName, "TestContent")
            {
                MailNotify = false,
            });

            Attachment attachment;
            using (var @params = new PostAttachmentParams("Test.txt",
                new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("TEST"))))
            {
                attachment = await client.PostAttachmentAsync(@params);
            }

            var attachments =  await client.AddWikiAttachmentAsync(new AddWikiAttachmentParams(wiki.Id, attachment.Id));
            Assert.AreEqual(attachments[0].Name, "Test.txt");

            var wikiGet = await client.GetWikiAsync(wiki.Id);
            Assert.AreEqual(wikiGet.Attachments[0].Id, attachments[0].Id);
            Assert.AreEqual(wikiGet.Attachments[0].Name, "Test.txt");

            using (var attachmentData = await client.DownloadWikiAttachmentAsync(wiki.Id, attachments[0].Id))
            {
                Assert.AreEqual(attachmentData.FileName, "Test.txt");
                using (var memoryStream = new MemoryStream())
                {
                    await attachmentData.Content.CopyToAsync(memoryStream);
                    var text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                    Assert.AreEqual(text, "TEST");
                }
            }

            var attachmentDeleted = await client.DeleteWikiAttachmentAsync(wiki.Id, attachments[0].Id);
            Assert.AreEqual(attachmentDeleted.Name, "Test.txt");

            wikiGet = await client.GetWikiAsync(wiki.Id);
            Assert.AreEqual(wikiGet.Attachments.Length, 0);

            await client.DeleteWikiAsync(wiki.Id, false);
        }
    }
}
