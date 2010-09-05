/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[Test]
public void Should_Add_A_Thought_On_Create()
{
  Thought newThought = new Thought
  {
    Id = 3,
    Name = "Research big screen TVs",
    Topic = Topic.Topics.Find(topic => topic.Name == "Home"),
  };

  var result = (RedirectToRouteResult)
    new ThoughtController().Create(newThought);

  Assert.Contains(newThought, Thought.Thoughts);
  Assert.AreEqual("Index", result.RouteValues["Action"]);
}
[Test]
public void Should_Add_A_Thought_And_Upload_An_Image_On_Create()
{
  Thought newThought = new Thought
  {
    Id = 3,
    Name = "Research big screen TVs",
    Topic = Topic.Topics.Find(topic => topic.Name == "Home"),
  };

  MockRepository mocks = new MockRepository(); 
  var file = mocks.Stub<HttpPostedFileBase>();
  Expect.Call(file.FileName).Return("bigscreen.jpg"); 
  Expect.Call(file.ContentLength).Return(12);
  mocks.Replay(file);

  var thoughtController = new ThoughtController();
  var builder = new TestControllerBuilder();
  builder.InitializeController(thoughtController);
  builder.Files["ImageAttachment"] = file; 

  thoughtController.Create(newThought).
    AssertActionRedirect().ToAction("Index");

  Assert.Contains(newThought, Thought.Thoughts);

  Assert.IsTrue(newThought.
    ImageAttachment.Contains("UserContent/")); 
  Assert.IsTrue(newThought.
    ImageAttachment.Contains("-bigscreen.jpg"));
}
[Test]
public void Should_Download_File_With_Random_Number_Removed_From_Name()
{
  var expectedThought = Thought.Thoughts.First();
  expectedThought.ImageAttachment = 
    "UserContent/232923-picture.jpg";

  var fileresult = new ThoughtController().
        Download(expectedThought.Id).
        AssertResultIs<FilePathResult>();

  //actual filename on web server
  Assert.AreEqual("~/UserContent/232923-picture.jpg", 
    fileresult.FileName);

  //file name that user downloads
  Assert.AreEqual("picture.jpg",fileresult.FileDownloadName);
}
