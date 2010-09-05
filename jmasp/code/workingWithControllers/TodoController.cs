/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public ActionResult Convert(Thought thought, string outcome)
{
  var newTodo = new Todo
  {
    Title = thought.Name,
    Outcome = outcome,
    Topic = Topic.
    Topics.Find(topic => 
      topic.Id == thought.Topic.Id)
  };
  
  CreateTodo(newTodo);
  
  Thought.Thoughts.RemoveAll(thoughtToRemove =>
    thoughtToRemove.Name == thought.Name); 

  return RedirectToAction("Process", "Thought"); 
}

private void CreateTodo(Todo todo) 
{
  Todo.ThingsToBeDone.Add(todo);
}
