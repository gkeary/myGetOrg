﻿using System.Web.Mvc;
using GetOrganized.Web.Controllers;
using GetOrganized.Web.Models;
using NUnit.Framework;
using System.Collections.Generic;
using MvcContrib.TestHelper;

namespace Test.Unit
{
    [TestFixture]
    public class TodoControllerTest
    {
        [SetUp]
        public void Setup()
        {
            Todo.ThingsToBeDone =
                new List<Todo>
                    {
                        new Todo() {Title = "Get Milk"},
                        new Todo() {Title = "Bring Home Bacon"}
                    };
        }

        [Test]
        public void Should_Display_A_List_Of_Todo_Items()
        {
            var viewResult = (ViewResult)new TodoController().Index();
            Assert.AreEqual(Todo.ThingsToBeDone, viewResult.ViewData.Model);
        }

        [Test]
        public void Should_Load_Create_View()
        {
            var viewResult = (ViewResult)new TodoController().Create();

            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [Test]
        public void Should_Add_Todo_Item()
        {
            var todo = new Todo { Title = "Learn to Use Alt-Enter" };

            var sessionSummary = new SessionSummary();
            sessionSummary.AddedTodos.Add(todo);

            var todoController = new TodoController();
            var builder = new TestControllerBuilder();
            builder.InitializeController(todoController);

            todoController.Create(todo).
                AssertActionRedirect().ToAction("Index");
            Assert.Contains(todo, Todo.ThingsToBeDone);

            Assert.AreEqual(sessionSummary,
                 todoController.Session["SessionSummary"]);


            var redirectToResult = (RedirectToRouteResult)new TodoController().Create(todo);

            Assert.Contains(todo, Todo.ThingsToBeDone);
            Assert.AreEqual("Index", redirectToResult.RouteValues["action"]);
        }

        [Test]
        public void Should_Delete_Todo_Item()
        {
            var mistakeTodo = Todo.ThingsToBeDone[0];
            var redirectToRouteResult = (RedirectToRouteResult)
                                        new TodoController().Delete(mistakeTodo.Title);

            Assert.IsFalse(Todo.ThingsToBeDone.Contains(mistakeTodo));
            Assert.AreEqual("Index",
                            redirectToRouteResult.RouteValues["action"]);
        }

        [Test]
        public void Should_Load_A_Todo_Item_For_Editing()
        {
            var editTodo = Todo.ThingsToBeDone[0];
            var viewResult = (ViewResult) new TodoController().Edit(editTodo.Title);

            Assert.AreEqual(editTodo, viewResult.ViewData.Model);
        }

        [Test]
        public void Should_Edit_Todo_Item()
        {
            var editedTodo = new Todo {Title = "Get A Lot More Milk"};

            var redirectToResult = (RedirectToRouteResult) new TodoController().Edit("Get Milk", editedTodo);

            Assert.Contains(editedTodo, Todo.ThingsToBeDone);
            Assert.AreEqual("Index",
                            redirectToResult.RouteValues["action"]);
        }

        [Test]
        public void Should_Convert_A_Thought_To_A_Todo()
        {
            var expectedTodo =
                new Todo
                    {
                        Title = "Build a killer web site",
                        Outcome = "Site has 100 visitors per day",
                        Topic = Topic.Topics[0]
                    };

            var thought =
                new Thought() {Name = "Build a killer web site", Topic = Topic.Topics[0]};

            var result = (RedirectToRouteResult) new TodoController()
               .Convert(thought, "Site has 100 visitors per day");

            Assert.Contains(expectedTodo,Todo.ThingsToBeDone);
            Assert.IsFalse(Thought.Thoughts.Contains(thought));
            Assert.AreEqual("Process",result.RouteValues["action"]);
            Assert.AreEqual("Thought",result.RouteValues["controller"]);
        }

    }
    }

