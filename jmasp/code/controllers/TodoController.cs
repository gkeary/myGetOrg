/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
private void CreateTodo(Todo todo)
{
  Todo.ThingsToBeDone.Add(todo);
  if (Session["SessionSummary"] == null) 
    Session["SessionSummary"] = new SessionSummary();

  var summary = ((SessionSummary) Session["SessionSummary"]); 
  summary.AddedTodos.Add(todo);
}
public ActionResult Index()
{
  ViewData["UserName"] = User.Identity.Name;
  ViewData.Model = Todo.ThingsToBeDone;
  
  return View();
}
