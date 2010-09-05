/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganized.Persistence.Repositories;
using MvcContrib.TestHelper;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Unit.Helper;

namespace Test.Unit.Controller
{
    [TestFixture]
    public class TodoControllerTest
    {
        private TestControllerBuilder builder;
        private TodoController todoController;
        private MockRepository mocks;
        private TodoRepository todoRepository;
        private ThoughtRepository thoughtRepository;
        private TopicRepository topicRepository;
        private ISession session;

        [SetUp]
        public void setup()
        {
            mocks = new MockRepository();
            builder = new TestControllerBuilder();
            session = mocks.DynamicMock<ISession>();
            todoRepository = mocks.StrictMock<TodoRepository>(session);
            thoughtRepository = mocks.StrictMock<ThoughtRepository>(session);
            topicRepository = mocks.StrictMock<TopicRepository>(session);
            todoController = new TodoController(todoRepository, null, thoughtRepository, topicRepository);
            builder.InitializeController(todoController);
        }

        [Test]
        public void Should_Load_Create_View()
        {
            var viewResult = (ViewResult) new TodoController(null, null, null, topicRepository).Create(); 
            Assert.AreEqual(string.Empty, viewResult.ViewName); 
        }

        [Test]
        public void Should_Display_A_List_Of_Todo_Items_And_Logged_In_Users_Name()
        {
            const string userName = "Jonathan";
            var todoList = new List<Todo> { new Todo { Title = "Refactor to NHibernate" } };

            builder.HttpContext.User = new GenericPrincipal(new GenericIdentity(userName), null);
            builder.HttpContext.Request.Expect(x => x.Headers).Return(new NameValueCollection());
            Expect.Call(todoRepository.GetAll()).Return(todoList);
            mocks.ReplayAll();

            var viewData = todoController.Index().AssertViewRendered().ViewData;

            Assert.AreEqual(todoList, viewData.Model);

            Assert.AreEqual(userName, viewData["UserName"]);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Add_Todo_Item()
        {
            var todo = new Todo {Title = "Learn MVC Controllers"};

            var sessionSummary = new SessionSummary();
            sessionSummary.AddedTodos.Add(todo);

            todoRepository.SaveOrUpdate(todo);
            LastCall.Repeat.Once();

            todoController.Create(todo).AssertActionRedirect().ToAction("Index");
            Assert.AreEqual(sessionSummary, todoController.Session["SessionSummary"]);
       }

        [Test]
        public void Should_Be_Logged_In_To_Create()
        {
            TestHelper.AssertIsAuthorized(typeof (TodoController), "Create");
            TestHelper.AssertIsAuthorized(typeof (TodoController), "Create", typeof (Todo));
        }

        [Test]
        public void Should_Be_Logged_In_To_Do_Anything_With_Todos()
        {
            TestHelper.AssertIsAuthorized(typeof (TodoController));
        }

        [Test]
        public void Should_Convert_A_Thought_Into_A_Todo_And_Redirect_To_Process_Thought()
        {
            var homeTopic = new Topic { Name = "Home" };

            var todo = new Todo
                           {
                               Title = "Do Laundry",
                               Outcome = "Laundry is clean and put away",
                               Topic = homeTopic
                           };

            var thought = new Thought { Id= 22, Name = "Do Laundry", Topic = homeTopic };

            Expect.Call(topicRepository.GetAll()).Return(new List<Topic> {homeTopic});
            Expect.Call(thoughtRepository.GetAll()).Return(new List<Thought> { thought });

            todoRepository.SaveOrUpdate(todo);
            LastCall.IgnoreArguments();;

            thoughtRepository.Delete(thought);
            LastCall.IgnoreArguments();

            mocks.ReplayAll();

            var result = (RedirectToRouteResult)
                         todoController.Convert(thought, "Laundry is clean and put away");

            Assert.AreEqual("Process", result.RouteValues["action"]);
            Assert.AreEqual("Thought", result.RouteValues["controller"]);

            mocks.VerifyAll();
        }

        [Test]
        public void Should_Delete_Todo_Item()
        {
            var todo = new Todo {Title="toDelete"}; 

            Expect.Call(todoRepository.GetAll()).Return(new List<Todo> 
                {todo});
            Expect.Call(() => todoRepository.Delete(todo));
            mocks.ReplayAll();
            
            var redirectToRouteResult = (RedirectToRouteResult) todoController.Delete("toDelete");

            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Display_Errors_When_Todo_Is_Not_Valid()
        {
            var invalidTodo =
                new Todo {Title = "123456789ABCDEF123456789ABCDEF"};

            var modelState = todoController.Create(invalidTodo).AssertViewRendered().ViewData.ModelState;

            Assert.IsTrue(modelState.ContainsKey("Title length must be between 0 and 25"));
        }

        [Test]
        public void Should_Edit_Todo_Item()
        {
            var todo = new Todo { Title = "toEdit" };

            Expect.Call(todoRepository.GetAll()).Return(new List<Todo> { todo });
            Expect.Call(() => todoRepository.SaveOrUpdate(todo));
            mocks.ReplayAll();

            var redirectToRouteResult = (RedirectToRouteResult) todoController.Edit(todo.Title, todo);

            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
            mocks.VerifyAll();
        }

        [Test]
        public void Should_Load_A_Todo_Item_For_Editing()
        {
            var todo = new Todo { Title = "toEdit" };

            Expect.Call(todoRepository.GetAll()).Return(new List<Todo> { todo });
            mocks.ReplayAll();

            var viewResult = (ViewResult) todoController.Edit(todo.Title);

            Assert.AreEqual(todo, viewResult.ViewData.Model);

            mocks.VerifyAll();
        }

        [Test]
        public void Should_Create_Todo_When_Making_Ajax_Call()
        {
            var todo = new Todo {Title = "get ajax working"};

            builder.HttpContext.Request.Expect(x => x["X-Requested-With"]).Return("XMLHttpRequest");
            todoRepository.Expect(x => x.SaveOrUpdate(todo));
            mocks.ReplayAll();

            var jsonResult = (JsonResult) todoController.Create(todo);

            Assert.AreEqual(todo, jsonResult.Data);
            mocks.VerifyAll();
        }
    }
}