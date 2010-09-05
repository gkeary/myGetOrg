/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Test]
public void Should_Convert_A_Thought_To_A_Someday()
{
  Thought writeACompiler = new Thought { Name = "Write a Compiler" };
  new ThoughtController().MakeASomeday(writeACompiler).
    AssertActionRedirect().ToAction("Process");
  Assert.Contains(writeACompiler, Thought.Somedays);
  Assert.IsFalse(Thought.CurrentThoughts.Contains(writeACompiler));
}
[Test]
public void Should_List_Topics_When_Creating_New_Thoughts()
{
  var expectedList = Topic.Topics;
  var viewDataOfTopics = new ThoughtController().
    Create().AssertViewRendered().ViewData["Topics"];
  Assert.AreEqual(expectedList, viewDataOfTopics);
}
