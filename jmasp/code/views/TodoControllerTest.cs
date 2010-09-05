/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Test]
public void Should_Display_Errors_When_Todo_Is_Not_Valid()
{
  var invalidTodo =
    new Todo {Title = "123456789ABCDEF123456789ABCDEF"};

  var modelState = todoController.Create(invalidTodo).
    AssertViewRendered().ViewData.ModelState;
  
  Assert.IsTrue(
    modelState.ContainsKey("Title length must be between 0 and 25"));
}

