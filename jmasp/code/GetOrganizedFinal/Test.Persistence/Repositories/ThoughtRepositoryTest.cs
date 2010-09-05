/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System.Collections;
using GetOrganized.Models;
using GetOrganized.Persistence.Repositories;
using NUnit.Framework;

namespace Test.Persistence.Repositories
{
    [TestFixture]
    public class ThoughtRepositoryTest : RepositoryTestBase
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            //remove this call to base cause Resharper 4.5 doesn't support NUnit 2.5 very well yet
            setup();

            repository = new ThoughtRepository(session);
        }

        #endregion

        private ThoughtRepository repository;

        private Thought CreateThought()
        {
            var thought = new Thought
                              {
                                  Name = "A Thought Provoking Thought",
                                  ImageAttachment = "image1.jpg"
                              };
            repository.SaveOrUpdate(thought);

            session.Flush();
            return thought;
        }

        [Test]
        public void Should_Create_And_Read()
        {
            Thought thought = CreateThought();
            var actual = (IList) repository.GetAll();
            Assert.Contains(thought, actual);
            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public void Should_Delete()
        {
            Thought originalThought = CreateThought();
            repository.Delete(originalThought);
            session.Flush();
            Assert.IsEmpty((ICollection) repository.GetAll());
        }

        [Test]
        public void Should_Edit()
        {
            Thought originalThought = CreateThought();

            session.Clear();


            Thought toModify = repository.Get(originalThought.Id);
            toModify.Name = "Get Update working";
            repository.SaveOrUpdate(toModify);

            session.Flush();

            var actual = (IList) repository.GetAll();
            Assert.Contains(toModify, actual);
            Assert.IsFalse(actual.Contains(originalThought));
        }
    }
}