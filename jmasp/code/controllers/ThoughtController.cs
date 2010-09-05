/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
//
// Inside ThoughtController...

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create(Thought newThought)
{
  newThought.Topic = 
    Topic.Topics.
    Find(topic => topic.Id == newThought.Topic.Id);
  
  HttpPostedFileBase file = Request.Files["ImageAttachment"]; 
  if (file.ContentLength != 0)
  {
    int randomNumber = 
      new Random().
      Next(100000, Int32.MaxValue); 
    string imgUrl = 
      "UserContent/" + randomNumber 
      + "-" + file.FileName;
    file.SaveAs(
      Server.MapPath("~/UserContent") + "/" + 
        randomNumber + "-" + file.FileName); 
    newThought.ImageAttachment = imgUrl;
  }

  Thought.Thoughts.Add(newThought);
  return RedirectToAction("Index");
}

//
// GET: /Thought/Download/5

public FilePathResult Download(int id)
{
  Thought thought = Thought.Thoughts.Find(x => x.Id == id);

  return File("~/" + 
    thought.ImageAttachment, "application/octet-stream",
      Path.GetFileName(thought.ImageAttachment)
          .Split(new[] {'-'}, 2)[1]);
}
