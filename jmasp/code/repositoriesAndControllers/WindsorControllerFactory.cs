/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class WindsorControllerFactory : DefaultControllerFactory
{
  private IWindsorContainer _container;

  protected override IController GetControllerInstance(
    RequestContext context, Type controllerType)
  {
    if(controllerType == null)
    {
      throw new HttpException(404,
        string.Format("The controller for path '{0}' " + 
        "could not be found or it does not implement IController.", 
        context.HttpContext.Request.Path));
    }

    return (IController)_container.Resolve(controllerType);
  }
}
