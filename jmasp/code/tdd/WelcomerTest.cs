/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using NUnit.Framework;

[TestFixture]
public class WelcomerTest
{

}

using NUnit.Framework;
[TestFixture]
public class WelcomerTest
{
  [Test]
  public void Should_Say_Hello_World()
  {
    // your testing happens here
  }
}
using NUnit.Framework;

[TestFixture]
public class WelcomerTest
{
  [Test]
  public void Should_Say_Hello_World()
  {
    Assert.AreEqual("Hello World", Welcomer.SayHello());
  }
}
Assert.That("Hello World", Is.EqualTo(new Welcomer().SayHello()))
