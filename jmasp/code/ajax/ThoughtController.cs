/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public ActionResult Search(string q) 
{
  var searchResults = Thought.CurrentThoughts.FindAll(
  thought => thought.Name.ToLower().Contains(q.ToLower())); 

  var autocompleteResults = 
    String.Join("\n", 
    searchResults.ConvertAll(g => g.Name).ToArray()); 

  return Content(autocompleteResults);
}
//
// GET: /Thought/FindDetails?nameOfThought={name}

public ActionResult FindDetails(string nameOfThought)
{
  var thought = Thought.CurrentThoughts.
    Find(x => x.Name == nameOfThought);
  
  return RedirectToAction("Details", 
    new { id = thought.Id }); 
}
