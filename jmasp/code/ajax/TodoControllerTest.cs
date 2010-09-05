/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[TestFixture]
public class TodoControllerTest
{
  private TestControllerBuilder builder;
  private TodoController todoController;

  [SetUp]
  public void setup()
  {
    builder = new TestControllerBuilder();
    todoController = new TodoController();
    builder.InitializeController(todoController);
  }
//ommited rest of class
}
