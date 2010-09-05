/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class Topic
{
  public static List<Topic> Topics = new List<Topic>
  {
   new Topic {Id = 1, Color = Color.Red, Name = "Work"},
   new Topic {Id = 2, Color = Color.Blue, Name = "Home"}
  };

  public int Id { get; set; }
  public Color Color { get; set; }
  public string Name { get; set; }

  public override bool Equals(object obj)
  {
    // reference equality check
	// if (ReferenceEquals(this, obj)) return true;
    // type equality check
    // if (obj.GetType() != typeof (Topic)) return false;
  
    var other = obj as Topic; 

    return other.Id == Id  
      && other.Color.Equals(Color)
      && Equals(other.Name, Name);
  }

  public override int GetHashCode()
  {
    return Id; //required for assisting with collections
  }
}
using System.Drawing;

//omit class definition

public string ColorInWebHex()
{
  return ColorTranslator.ToHtml(Color);
}
