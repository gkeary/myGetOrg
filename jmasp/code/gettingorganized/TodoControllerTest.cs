/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using NUnit.Framework;

namespace Test.Unit
{
  [TestFixture]
  public class TodoControllerTest
  {
    [Test]
    public void Should_Display_A_List_Of_Todo_Items()
    {
        
    }
  }
}
[Test]
public void Should_Display_A_List_Of_Todo_Items()
{
    var viewResult = (ViewResult) new TodoController().Index() ;
    Assert.AreEqual(Todo.ThingsToBeDone, viewResult.ViewData.Model ); 
}
[SetUp] 
public void setup()
{
  Todo.ThingsToBeDone = new List<Todo>
    {
      new Todo {Title = "Get Milk"},
      new Todo {Title = "Bring Home Bacon"}
    };
}

[Test]
public void Should_Add_Todo_Item()
{
  var todo = new Todo {
    Title = "Learn more about ASP.NET MVC Controllers" };

  var redirectToRouteResult = 
    (RedirectToRouteResult) new TodoController().Create(todo);

  Assert.Contains(todo, Todo.ThingsToBeDone);
  Assert.AreEqual("Index", 
    redirectToRouteResult.RouteValues["action"]); 
}
[Test]
public void Should_Delete_Todo_Item()
{
  var mistakeTodo = Todo.ThingsToBeDone[0];

  var redirectToRouteResult = (RedirectToRouteResult) 
    new TodoController().Delete(mistakeTodo.Title);

  Assert.IsFalse(Todo.ThingsToBeDone.Contains(mistakeTodo)); 
  Assert.AreEqual("Index", 
    redirectToRouteResult.RouteValues["action"]);
}
[Test]
public void Should_Load_A_Todo_Item_For_Editing()
{
  var editTodo = Todo.ThingsToBeDone[0];

  var viewResult = (ViewResult) new TodoController().Edit(editTodo.Title);

  Assert.AreEqual(editTodo, viewResult.ViewData.Model);
}
[Test]
public void Should_Edit_Todo_Item()
{
  var editedTodo =  new Todo { Title = "Get A LOT MORE milk" };

  var redirectToRouteResult = 
    (RedirectToRouteResult)
      new TodoController().Edit("Get Milk",editedTodo);

  Assert.Contains(editedTodo, Todo.ThingsToBeDone);
  Assert.AreEqual("Index", 
    redirectToRouteResult.RouteValues["action"]);
}
[Test]
public void Should_Load_Create_View()
{  
  var viewResult = (ViewResult) new TodoController().Create();

  Assert.AreEqual(string.Empty, viewResult.ViewName); 
}
