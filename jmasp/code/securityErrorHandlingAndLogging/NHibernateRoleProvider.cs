/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
public class NHibernateRoleProvider : RoleProvider
{
  private RoleRepository roleRepository;
  
  public NHibernateRoleProvider()
  {
    roleRepository = new RoleRepository();
  }
  
  public NHibernateRoleProvider(RoleRepository roleRepository)
  {
    this.roleRepository = roleRepository;
  }
  
  public override void AddUsersToRoles(
    string[] usernames, string[] roleNames)
  {
    roleRepository.AddUsersToRoles(usernames, roleNames);
  }
  
  //omit rest of class implementation
}
