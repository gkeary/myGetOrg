/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[TestFixture]
public class ThoughtControllerTest
{
  [Test]
  public void Should_List_Thoughts_When_Index_Is_Called()
  {
    var result = (ViewResult) new ThoughtController().Index();

    Assert.AreEqual(Thought.Thoughts, result.ViewData.Model);
  }
}
[Test]
public void Should_Provide_A_List_Of_Topics_For_Creating_New_Thoughts()
{
  var expectedListItems =
    Topic.Topics.ConvertAll(topic => 
      new SelectListItem 
      {Text = topic.Name, Value = topic.Id.ToString()});
      
  var result = (ViewResult)new ThoughtController().Create();
  
  var firstTopic = 
    ((List<SelectListItem>) result.ViewData["Topics"])[0]; 
  Assert.AreEqual(expectedListItems[0].Value, firstTopic.Value);  
  Assert.AreEqual(expectedListItems[0].Text, firstTopic.Text);
}
using System.Linq; 

public class ThoughtControllerTest
{
  [Test]
  public void Should_Display_First_Thought_When_Processing_Thoughts()
  {
    var expectedThought = Thought.Thoughts.First(); 
    var result = (ViewResult) new ThoughtController().Process();
    Assert.AreEqual(expectedThought, result.ViewData.Model);
  }
}
