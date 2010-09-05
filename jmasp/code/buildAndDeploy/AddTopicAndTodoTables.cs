/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Migration(20100101081010)]
public class AddTopicAndTodoTables : Migration
{
  public override void Up()
  {
    Database.AddTable("Topic", 
      new Column("Id", DbType.Int32, ColumnProperty.PrimaryKey),
      new Column("Name", DbType.String, 100),
      new Column("ColorHtml", DbType.String, 255)
     );  

    Database.AddTable("Todo",
      new Column("Id", DbType.Int32, ColumnProperty.PrimaryKey),
      new Column("Title", DbType.String, 25),
      new Column("Outcome", DbType.String, 100),
      new Column("Complete", DbType.Boolean),
      new Column("Topic_Id", DbType.Int32) 
     );

    Database.AddForeignKey("FK_Todo_Topic", 
      "Todo", "Topic_Id", "Topic", "Id"); 
  }
  
  public override void Down()
  {
    Database.RemoveForeignKey("Todo", "FK_Todo_Topic"); 
    Database.RemoveTable("Todo");
    Database.RemoveTable("Topic");
  }
}
