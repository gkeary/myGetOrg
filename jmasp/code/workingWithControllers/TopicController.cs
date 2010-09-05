/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class TopicController : Controller
{
  //
  // GET: /Topic/

  public ActionResult Index()
  {
    ViewData.Model = Topic.Topics;
    return View();
  }
}
//
// POST: /Topic/Create

[HttpPost]
public ActionResult Create(FormCollection collection) 
{
  var newTopic = new Topic();
  newTopic.Id = Convert.ToInt32(collection["Id"]); 
  newTopic.Name = collection["Name"];
  newTopic.Color =  
    ColorTranslator.FromHtml("#" + collection["Color"]);
  
  Topic.Topics.Add(newTopic);
  TempData["message"] = "Your topic has been added successfully."; 
  return RedirectToAction("Index");
}
