/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[TestFixture]
public class TopicTest
{
  private Topic workTopic;
  
  [SetUp] 
  public void Setup()
  {
    workTopic = new Topic { Id = 1, 
      Color = Color.White, Name = "Work" };
  }
  
  [Test]
  public void Should_Be_Equal_By_Value()
  {
    var anotherWorkTopic = new Topic {Id = 1, 
      Color = Color.White, Name = "Work"};
    Assert.AreEqual(workTopic, anotherWorkTopic);
  }
  
  [Test]
  public void Should_Not_Be_Equal_By_Value()
  {
    var personalTopic = new Topic { Id = 2, 
      Color = Color.Red, Name = "Personal" };
    Assert.AreNotEqual(workTopic, personalTopic);
  }
}
[Test]
public void Should_Convert_Color_To_Hex_Value()
{
  var aShadeOfRedTopic = 
    new Topic { Color = Color.FromArgb(0, 208, 0, 0)};
  Assert.AreEqual("#D00000", 
    aShadeOfRedTopic.ColorInWebHex());
}
