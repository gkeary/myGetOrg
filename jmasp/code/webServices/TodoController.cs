/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public ActionResult Index()
{
    ViewData["UserName"] = User.Identity.Name;

    ViewData.Model = repository.GetAll();
    
    if (Request.Headers["Content-Type"] == "text/xml")
        return new XmlResult(ViewData.Model);
    else
      return View();
}
[Authorize]
[AcceptVerbs(HttpVerbs.Post)]
public ActionResult CreateWithXml(
  [ModelBinder(typeof(TodoXmlBinder))] Todo todo)
{
  Create(todo);
  return new XmlResult(todo);
}
private readonly TodoRepository repository;
private readonly BloggerGateway gateway;

public TodoController(TodoRepository repository, 
  BloggerGateway gateway)
{
  this.repository = repository;
  this.gateway = gateway;
}
public ActionResult PublishToBlogger(string title)
{
  Todo todo = repository.GetAll().Where(x => x.Title == title).First();
  
  return Redirect(gateway.AuthenticateURL(todo.Title));
}
public ActionResult BloggerAuthorized(string title, string token)
{
  var todo = repository.GetAll().Where(x => x.Title == title);
  
  gateway.PublishAsDraft(todo, token);
  
  return Redirect("http://jonathanmccracken.blogspot.com");
}
