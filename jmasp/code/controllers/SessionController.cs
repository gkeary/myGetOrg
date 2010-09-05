/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class SessionController : Controller
{
  public ActionResult Index()
  {
    if (Session["SessionSummary"] == null)
      Session["SessionSummary"] = new SessionSummary();

    return View(Session["SessionSummary"]); 
  }
}