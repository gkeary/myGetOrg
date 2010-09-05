/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections;
using GetOrganized.Models;
using GetOrganized.Persistence.Repositories;
using NUnit.Framework;

namespace Test.Persistence.Repositories
{
    [TestFixture]
    public class TodoRepositoryTest : RepositoryTestBase
    {
        private TodoRepository repository;

        [SetUp]
        public void Setup()
        {
            //remove this call to base cause Resharper 4.5 doesn't support NUnit 2.5 very well yet
            setup();

            repository = new TodoRepository(session);
        }

        [Test]
        public void Should_Create_And_Read()
        {
            Todo todo = CreateTodo();
            var actual = (IList) repository.GetAll();
            Assert.Contains(todo, actual);
            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public void Should_Edit()
        {
            var originalTodo = CreateTodo();
            
            //clear cleans up the session's cache
            session.Clear();


            var toModify = repository.Get(originalTodo.Id);
            toModify.Outcome = "Get Update working";
            repository.SaveOrUpdate(toModify);

            session.Flush();

            var actual = (IList)repository.GetAll();
            Assert.Contains(toModify, actual);
            Assert.IsFalse(actual.Contains(originalTodo));
        }

        [Test]
        public void Should_Delete()
        {
            var originalTodo = CreateTodo();
            repository.Delete(originalTodo);
            session.Flush();
            Assert.IsEmpty((ICollection) repository.GetAll());
        }


        private Todo CreateTodo()
        {
            var todo = new Todo {Title = "Build Repositories", 
                                 Outcome = "Database is working"};
            repository.SaveOrUpdate(todo);

            session.Flush();
            return todo;
        }
    }
}