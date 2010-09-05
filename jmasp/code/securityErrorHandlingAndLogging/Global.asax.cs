/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
protected void Application_Error()
{
  Exception error = Server.GetLastError();
  
  // log something using this exception
}
public void Application_Start()
{
  //omitted other code
  FileAppender appender = new FileAppender();
  appender.File = "GetOrganized.log";
  log4net.Config.BasicConfigurator.Configure(appender);
}
public void RegisterWindsor(IContainer container)
{
  //omitted other registerations
  
  container.AddFacility("logging", 
     new LoggingFacility(LoggerImplementation.Log4Net)); 
}
protected void Application_Error()
{
  Exception error = Server.GetLastError();
  container.Get<ILogger>().Fatal(error);
}
