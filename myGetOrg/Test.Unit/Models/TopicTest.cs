using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GetOrganized.Web.Models;
using NUnit.Framework;

namespace Test.Unit.Models
{
    [TestFixture]
    class TopicTest
    {
        private Topic workTopic;
        
        [NUnit.Framework.SetUp]
        public void Setup()
        {
            workTopic = new Topic {Id = 1, Color = Color.White, Name = "Work"};
        }

        [Test]
        public void Should_Be_Equal_By_Value()
        {
            var anotherWorkTopic = new Topic() {Id = 1, Color = Color.White, Name = "Work"};
            Assert.AreEqual(workTopic, anotherWorkTopic);
        }

        [Test]
        public void Should_Not_Be_Equal_By_Value()
        {
            var personalTopic = new Topic() {Id = 2, Color = Color.Red, Name = "Personal"};
            Assert.AreNotEqual(workTopic, personalTopic);
        }

        [Test]
        public void Should_Convert_Color_To_Hex_Value()
        {
            var aShadeOfRedTopic =
                new Topic {Color = Color.FromArgb(0, 208, 0, 0)};
            Assert.AreEqual("#D00000",aShadeOfRedTopic.ColorInWebHex());

        }
    }
}
