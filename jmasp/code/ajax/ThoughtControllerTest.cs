/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Test]
public void Should_Find_Thoughts_By_Text_Match_Case_Insensitive()
{
  var learnCsharp = Thought.CurrentThoughts[0];
  var contentResult = (ContentResult) 
    new ThoughtController().Search("learn"); 

  Assert.AreEqual(learnCsharp.Name, contentResult.Content);
}
[Test]
public void Should_Find_Thought_By_Name_And_Redirect_To_Details_View()
{
  var routeValueDictionary = new ThoughtController(). 
    FindDetails("Learn C# 3.5").
    AssertActionRedirect().RouteValues;

  Assert.AreEqual("Details", routeValueDictionary["action"]);
  Assert.AreEqual(1, routeValueDictionary["id"]);
}
