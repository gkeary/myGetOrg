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
            var topic = new Topic { Id = 1, Color = Color.Red, Name = "Work" };
            var model =
                ((ViewResult)new TopicController().Index()).ViewData.Model;
            Assert.AreEqual(topic, ((List<Topic>)model)[0]);
        }

        [Test]
        public void Should_Create_Topic_And_Notify_The_User()
        {
            var professionalDevelopment =
                new Topic
                {
                    Id = 3,
                    Color = ColorTranslator.FromHtml("#000000"),
                    Name = "Professional Development"
                };

            var formValues = new FormCollection();
            formValues.Add("Id", professionalDevelopment.Id.ToString());
            formValues.Add("Name",professionalDevelopment.Name);
            formValues.Add("Color",
                professionalDevelopment.ColorInWebHex().Trim('#'));

            var controller = new TopicController();

            var result = (RedirectToRouteResult) controller.Create(formValues);
            Assert.Contains(professionalDevelopment, Topic.Topics);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Your topic has been added successfully.",
                            controller.TempData["message"]);
        }

    }
}