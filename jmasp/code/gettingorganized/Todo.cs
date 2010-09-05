/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
namespace GetOrganized.Models
{
  public class Todo
  {
    public static List<Todo> ThingsToBeDone = new List<Todo>
    {
      new Todo {Title = "Get Milk", Completed = false},
      new Todo {Title = "Bring Home Bacon", Completed = false}
    };

    public bool Completed { get; set; } 
    public string Title { get; set; }
  }
}
