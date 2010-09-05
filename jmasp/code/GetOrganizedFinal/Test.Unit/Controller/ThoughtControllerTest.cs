/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganized.Persistence.Repositories;
using NHibernate;
using NUnit.Framework;
using System.Linq;
using MvcContrib.TestHelper;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Is=NUnit.Framework.Is;

namespace Test.Unit.Controller
{
    [TestFixture]
    public class ThoughtControllerTest
    {
        private TestControllerBuilder builder;
        private ThoughtController thoughtController;
        private MockRepository mocks;
        private ThoughtRepository thoughtRepository;
        private TopicRepository topicRepository;
        private ISession session;

        [SetUp]
        public void setup()
        {
            mocks = new MockRepository();
            builder = new TestControllerBuilder();
            session = mocks.DynamicMock<ISession>();
            thoughtRepository = mocks.StrictMock<ThoughtRepository>(session);
            topicRepository = mocks.StrictMock<TopicRepository>(session);
            thoughtController = new ThoughtController(thoughtRepository, topicRepository);
            builder.InitializeController(thoughtController);
        }
 
        [Test]
        public void Should_List_Thoughts_When_Index_Is_Called()
        {
            var thoughts = new List<Thought>();

            Expect.Call(thoughtRepository.GetAll()).Return(thoughts);
            mocks.ReplayAll();

            var result = (ViewResult)thoughtController.Index();

            Assert.AreEqual(thoughts, result.ViewData.Model);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Provide_A_List_Of_Topics_For_Creating_New_Thoughts()
        {
            var topics = new List<Topic>();
            
            Expect.Call(topicRepository.GetAll()).Return(topics);
            mocks.ReplayAll();

            var viewDataOfTopics = thoughtController.
                Create().AssertViewRendered().ViewData["Topics"];
            Assert.AreEqual(topics, viewDataOfTopics);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Display_First_Thought_In_List_When_Processing_Thoughts()
        {
            var unprocessedThoughts = new List<Thought>{ new Thought {Name="another"}};

            Expect.Call(thoughtRepository.GetAll()).Return(unprocessedThoughts);
            mocks.ReplayAll();

            var result = (ViewResult)thoughtController.Process();

            Assert.AreEqual(unprocessedThoughts.First(), result.ViewData.Model);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Download_A_File_With_Random_Number_Removed_From_Name()
        {
            var expectedThought = new Thought { ImageAttachment = "UserContent/23923-picture.jpg" };

            Expect.Call(thoughtRepository.GetAll()).Return(new List<Thought> {expectedThought});
            mocks.ReplayAll();

            var fileresult = thoughtController.Download(expectedThought.Id).
                AssertResultIs<FilePathResult>();


            //actual filename on web server
            Assert.AreEqual("~/UserContent/23923-picture.jpg", fileresult.FileName);

            //file name that user downloads
            Assert.AreEqual("picture.jpg", fileresult.FileDownloadName);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Convert_A_Thought_To_A_Someday()
        {
            var writeACompiler = new Thought { Name = "Write a Compiler" };

            Expect.Call(() => thoughtRepository.SaveOrUpdate(writeACompiler));
            mocks.ReplayAll();

            thoughtController.MakeASomeday(writeACompiler).AssertActionRedirect().ToAction("Process");
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Find_Thoughts_By_Text_Match_Case_Insensitive()
        {
           var learnCSharp = new Thought {Name = "Learn C#"};
            
           Expect.Call(thoughtRepository.GetAll()).Return(new List<Thought> { learnCSharp});
           mocks.ReplayAll();

           var contentResult = (ContentResult) thoughtController.Search("learn");

           Assert.AreEqual(learnCSharp.Name, contentResult.Content);

           mocks.VerifyAll();
        }

        [Test]
        public void Should_Find_Thought_By_Name_And_Redirect_To_Details_View()
        {
            var learnCSharp = new Thought { Id = 1, Name = "Learn C# 3.5" };
                       
            Expect.Call(thoughtRepository.GetAll()).Return(new List<Thought> { learnCSharp });
            mocks.ReplayAll();

            var routeValueDictionary = thoughtController.FindDetails("Learn C# 3.5").
                AssertActionRedirect().RouteValues;

            Assert.AreEqual("Details", routeValueDictionary["action"]);
            Assert.AreEqual(1, routeValueDictionary["id"]);
            mocks.VerifyAll();
        }
    }
}