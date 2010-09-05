/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using NUnit.Framework;

namespace Test.Unit.Helper
{
    public class TestHelper
    {
        public static void AssertIsAuthorized(ICustomAttributeProvider type)
        {
            Assert.IsTrue(type.GetCustomAttributes(false).
                              Any(o => o.GetType() == typeof (AuthorizeAttribute)));
        }

        public static void AssertIsAuthorized(Type type, string action, params Type[] parameters)
        {
            AssertIsAuthorized(type.GetMethod(action, parameters));
        }
    }
}