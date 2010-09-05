/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public static class ColorDropDownHelper
{
  public static string Topic(string name, List<Topic> options)
  {
    var select = new TagBuilder("select"); //(1)
    select.MergeAttribute("style", "background-color: transparent;"); //(2)
    select.MergeAttribute("name", name);
    select.GenerateId(name);

    var optionBuilder = new StringBuilder(); //(3)

    foreach (var option in options)
    {
      var optionTag = new TagBuilder("option");
      optionTag.MergeAttribute("value", option.Id.ToString()); //(4)
      optionTag.MergeAttribute("style", "color: white; background-color: "
        + ColorTranslator.ToHtml(option.Color)); //(5)
      optionTag.SetInnerText(option.Name);
      optionBuilder.Append(
        optionTag.ToString(TagRenderMode.Normal));//(6)
    }
    
    select.InnerHtml = optionBuilder.ToString();//(7)
    return select.ToString(TagRenderMode.Normal);
  }
}
