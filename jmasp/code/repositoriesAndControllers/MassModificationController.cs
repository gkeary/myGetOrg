/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class MassModificationController : Controller
{
  [Transaction]
  public ActionResult UpdateTimeStamp()
  {
    for (int i = 1; i < 1001; i++)
    {
      var model = repository.Get(i);
      model.LastUpdated = DateTime.Now;
      repository.SaveOrUpdate(model);
    }
  }
}
