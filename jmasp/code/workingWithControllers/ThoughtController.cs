/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class ThoughtController : Controller
{
  //
  // GET: /Thought/

  public ActionResult Index()
  {
    ViewData.Model = Thought.Thoughts;
    return View();
  }
}
public ActionResult Create()
{
  ViewData["Topics"] = Topic.Topics.ConvertAll(topic => 
    new SelectListItem { 
    Text = topic.Name, Value = topic.Id.ToString() 
    });
  return View();
} 
//
// GET: /Thought/Process

public ActionResult Process()
{
  ViewData.Model = Thought.Thoughts.First();
  return View();
}
