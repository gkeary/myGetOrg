/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class Quote
{
  private static Random randomizer = new Random();
  
  private static List<Quote> FamousQuotes = 
    new List<Quote>
      {
        new Quote{Author="Andy Warhol", 
          Contents="In the future everyone " + 
            "will be world-famous for fifteen minutes."},
        new Quote{Author="Louis Hector Berlioz", 
          Contents="Time is a great teacher, " +
            "but unfortunately it kills all its pupils."}
      };
  
  public string Contents { get; set; }
  public string Author { get; set; }
  
  public static Quote ChooseRandomQuote() 
  {
      int randomIndex = randomizer.Next(FamousQuotes.Count);
      return FamousQuotes[randomIndex];
  }
}
