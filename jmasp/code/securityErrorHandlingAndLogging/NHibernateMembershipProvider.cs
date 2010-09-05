/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class NHibernateMembershipProvider : MembershipProvider
{
   private UserRepository userRepository;
   
   public NHibernateMembershipProvider()
   {
    userRepository = new UserRepository();
   }

   public NHibernateMembershipProvider(UserRepository userRepository)
   {
    this.userRepository = userRepository;
   }

  public override MembershipUser CreateUser(
    string username, string password,
    string email, string passwordQuestion,
    string passwordAnswer, bool isApproved,
    Object providerUserKey,
    out MembershipCreateStatus status)
    
    {
      userRepository.Create(username, password, email);
      status = status.Success;
      
    }
  
  //omit rest of the implementation of the class
}
