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
    using Internal.Json.CustomFields;

    [TestClass]
    public class CustomFieldsJsonImplTest
    {
        [TestMethod]
        public void TestCheckBoxCustomField()
        {
            var json = @"{id: 1, fieldTypeId:7, name: ""radio1"", value: [ {id: 2, name: ""item1"", displayOrder:99 }], otherValue:""other1""}";

            var obj = JsonConvert.DeserializeObject<CustomField>(json, new CustomFieldJsonImpl.JsonConverter());
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj is CheckBoxCustomField);
            var c = (CheckBoxCustomField)obj;
            Assert.AreEqual(c.Id, 1);
            Assert.AreEqual(c.FieldType, CustomFieldType.CheckBox);
            Assert.AreEqual(c.Name, "radio1");
            Assert.AreEqual(c.Value.Count, 1);
            Assert.AreEqual(c.Value[0].Id, 2);
            Assert.AreEqual(c.Value[0].Name,"item1");
            Assert.AreEqual(c.Value[0].DisplayOrder, 99);
            Assert.AreEqual(c.OtherValue, "other1");

            var json2 = JsonConvert.SerializeObject(c);
            Assert.IsTrue(json2 != null && json2.Length > 0);
        }
    }
}
