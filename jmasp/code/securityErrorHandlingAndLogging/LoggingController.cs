/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class LoggingController : Controller
{
  private ILogger logger;
  
  public LoggingController(ILogger logger)
  {
    this.logger = logger;
  }
}
public ActionResult LoggingTest()
{
  logger.Debug("debugging");
  logger.Info("application started up");
  logger.Warn("something bad may happen");
  logger.Error("something bad happened");
  logger.Fatal("something really bad happened");
}

