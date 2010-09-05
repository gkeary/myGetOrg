/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class Thought
{
  public static List<Thought> Somedays = new List<Thought> 
  {
  new Thought{Name = "Learn Smalltalk", 
    Topic = Topic.Topics.Find(topic => topic.Name == "Work")}
  };
  
  public static List<Thought> CurrentThoughts = new List<Thought> 
  {
  new Thought{Name = "Learn C# 3.5", 
    Topic = Topic.Topics.Find(topic => topic.Name == "Work")},
  new Thought{Name = "Build a Killer Web Application", 
    Topic = Topic.Topics.Find(topic => topic.Name == "Home")}
  };
  
  public int Id { get; set; }
  public Topic Topic { get; set; }
  public string Name { get; set; }
  public string ImageAttachment { get; set; }
}
