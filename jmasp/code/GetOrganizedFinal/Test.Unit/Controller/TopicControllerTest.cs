/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganized.Persistence.Repositories;
using MvcContrib.TestHelper;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;

namespace Test.Unit.Controller
{
    [TestFixture]
    public class TopicControllerTest
    {
        private TestControllerBuilder builder;
        private TopicController topicController;
        private MockRepository mocks;
        private TopicRepository topicRepository;
        private ISession session;

        [SetUp]
        public void setup()
        {
            mocks = new MockRepository();
            builder = new TestControllerBuilder();
            session = mocks.DynamicMock<ISession>();
            topicRepository = mocks.StrictMock<TopicRepository>(session);
            topicController = new TopicController(topicRepository);
            builder.InitializeController(topicController);
        }


        [Test]
        public void Should_Have_List_Of_Topics_With_Name_And_Color()
        {
            Expect.Call(topicRepository.GetAll()).Return(new List<Topic>());
            mocks.ReplayAll();

            topicController.Index().AssertViewRendered();

            mocks.VerifyAll();
        }

        [Test]
        public void Should_Add_A_Topic_When_Create_With_Post_Is_Called_And_Notify_The_User()
        {
            var professionalDevelopment = new Topic {Id = 3, 
                Color = ColorTranslator.FromHtml("#000000"), Name = "Professional Development"};

            var collection = new FormCollection();
            collection.Add("Id", professionalDevelopment.Id.ToString());
            collection.Add("Name", professionalDevelopment.Name);
            collection.Add("Color", ColorTranslator.ToHtml(professionalDevelopment.Color).Trim('#'));


            topicRepository.SaveOrUpdate(professionalDevelopment);
            LastCall.IgnoreArguments();
            mocks.ReplayAll();

            var result = (RedirectToRouteResult) topicController.Create(collection);


            mocks.VerifyAll();

            Assert.AreEqual("Index", result.RouteValues["action"]); 
            Assert.AreEqual("Your topic has been added successfully.", topicController.TempData["message"]); 
        }
    }
}