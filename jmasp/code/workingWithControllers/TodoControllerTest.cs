/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Test]
public void Should_Convert_A_Thought_To_A_Todo()
{
  var expectedTodo = new Todo  
  {
   Title = "Build a killer web site",
   Outcome = "Site has 100 visitors per day",
   Topic = Topic.Topics[0]
  };

  var thought = new Thought 
    {Name = "Build a killer web site", Topic = Topic.Topics[0]};

  var result = (RedirectToRouteResult) new TodoController().
    Convert(thought, "Site has 100 visitors per day"); 

  Assert.Contains(expectedTodo, Todo.ThingsToBeDone); 
  Assert.IsFalse(Thought.Thoughts.Contains(thought));
  Assert.AreEqual("Process", result.RouteValues["action"]);
  Assert.AreEqual("Thought", result.RouteValues["controller"]);
}
