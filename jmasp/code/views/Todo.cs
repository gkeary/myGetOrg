/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class Todo : IValidatable
{
  public string Title { get; set; }
        
  public void Validate(ModelStateDictionary state) 
  {
    if (Title.Length > 25)
      state.AddModelError("Title", 
      "Name must not exceed 25 characters" ); 
  }
  //... omitted rest of class ...
}
