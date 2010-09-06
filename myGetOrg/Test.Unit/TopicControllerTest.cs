using System.Drawing;
using System.Web.Mvc;
using GetOrganized.Web.Controllers;
using GetOrganized.Web.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test.Unit

{
    [TestFixture]
    public class TopicControllerTest
    {
        [Test]
        public void Should_Have_List_Of_Topics_With_Name_And_Color()
        {
            var topic = new Topic {Id = 1, Color = Color.Red, Name = "Work"};
            var model =
                ((ViewResult) new TopicController().Index()).ViewData.Model;
            Assert.AreEqual(topic, ((List<Topic>) model)[0]);
        }
        
    }
}