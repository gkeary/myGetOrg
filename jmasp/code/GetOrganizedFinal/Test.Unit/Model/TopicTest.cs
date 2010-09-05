/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Drawing;
using GetOrganized.Models;
using NUnit.Framework;

namespace Test.Unit.Model
{
    [TestFixture]
    public class TopicTest
    {
        private Topic school;

        [SetUp]
        public void Setup()
        {
            school = new Topic { Id = 1, Color = Color.White, Name = "School" };
        }
        
        [Test]
        public void Should_Be_Equal_By_Value()
        {
            var sameSchool = new Topic {Id = 1, Color = Color.White, Name = "School"};
            Assert.AreEqual(school, sameSchool);
        }

        [Test]
        public void Should_Not_Be_Equal_By_Value()
        {
            var renovation = new Topic { Id = 2, Color = Color.White, Name = "Renovation" };
            Assert.AreNotEqual(school, renovation);
        }
    }
}