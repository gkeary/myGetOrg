/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
// GET: /Todo/Delete/Title={name of todo}
[AllowedVerbs(HttpVerb.HttpPost)] 
public ActionResult Delete(string title)
{
  Todo.ThingsToBeDone.
    Remove(
    Todo.ThingsToBeDone.Find(todo => todo.Title == title));
    
  if (Request.IsAjaxRequest()) 
    return new EmptyResult();

  return RedirectToAction("Index");
}
// POST: /Todo/Create
[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create(Todo todo)
{
  todo.Validate(ModelState);

  if (ModelState.IsValid) 
  {
    CreateTodo(todo);
    if (Request.IsAjaxRequest()) 
      return Json(todo);
    return RedirectToAction("Index");
  }
  else 
  {
    return View();
  }
}
