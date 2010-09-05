/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[TestFixture]
public class BloggerGatewayTest
{
  [Test]
  public void Should_Authenticate_With_Blogger()
  {
    var gateway = new BloggerGateway();
    var googleURL = gateway.AuthenticateURL("foo");

    Assert.AreEqual(
      "https://www.google.com/accounts/AuthSubRequest?" +
      "next=http://10.1.10.12:1901/Todo/BloggerAuthorized" +
      "?title=foo&scope=" +
      "http://www.blogger.com/feeds/2580952471083668495/" +
      "posts/default", googleURL);
  }
}
