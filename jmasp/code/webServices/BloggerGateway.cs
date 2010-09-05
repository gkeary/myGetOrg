/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class BloggerGateway
{
  const string ipAddressOfSite = "10.1.10.12";  
  const long blogId = 2580952471083668495;
    
   public string AuthenticateURL(string todoTitle)
   {
     return string.Format(
       "https://www.google.com/accounts/AuthSubRequest" +
       "?next=http://{0}/Todo/BloggerAuthorized?title={1}" +
       "&scope=http://www.blogger.com/feeds/{2}/posts/default"
       , ipAddressOfSite, todoTitle, blogId);
   }
}
public void PublishAsDraft(Todo todo, string token)
{
  string xml = string.Format(
  @"<entry xmlns='http://www.w3.org/2005/Atom'>
  <title type='text'>{0}</title>
  <content type='xhtml'>
  <p>Empty</p>
  </content>
  <app:control xmlns:app='http://purl.org/atom/app#'>
  <app:draft>yes</app:draft>
  </app:control>
  </entry>", todo.Title);

  string blogFeedUri = "http://www.blogger.com/feeds/" + 
    blogId + "/posts/default";

  var response = 
    WebServiceUtil.SendWebRequestWithAuthToken(blogFeedUri, xml, 
    "application/atom+xml", token);
  
  if (response.StatusCode != HttpStatusCode.Created)
    throw new WebException(response.StatusCode.ToString());
}

