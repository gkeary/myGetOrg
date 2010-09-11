using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GetOrganized.Web.Controllers;
using GetOrganized.Web.Models;
using NUnit.Framework;

namespace Test.Unit
{
    [TestFixture]
    public class ThoughtControllerTest
    {
        [Test]
        public void Should_List_Thoughts_When_Index_Is_Called()
        {
            var result = (ViewResult)new ThoughtController().Index();
            Assert.AreEqual(Thought.Thoughts, result.ViewData.Model);
        }

        [Test]
        public void Should_Provide_A_List_Of_Topics_For_Creating_New_Thought()
        {
            var expectedListItems = Topic.Topics.ConvertAll(
                topic =>
                   new SelectListItem
                   {
                     Text = topic.Name,
                     Value = topic.Id.ToString()
                   });

            var result = (ViewResult) new ThoughtController().Create();

            var firstTopic =
                ((List<SelectListItem>) result.ViewData["Topics"])[0];

            Assert.AreEqual(expectedListItems[0].Value, firstTopic.Value);
            Assert.AreEqual(expectedListItems[0].Text, firstTopic.Text);
        }

        [Test]
        public void Should_Display_First_Thought_When_Processing_Thoughts()
        {
            var expectedThought = Thought.Thoughts.First();
            var result = (ViewResult) new ThoughtController().Process();
            Assert.AreEqual(expectedThought, result.ViewData.Model);
        }

        [Test]
        public void Should_Have_A_Non_Null_List_In_The_Process_Method()
        {
            var expectedThought = Thought.Thoughts.First();
            var result = new ThoughtController().Process();
        }
    }
}
