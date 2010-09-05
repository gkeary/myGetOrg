/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿
public class MvcApplication : HttpApplication
{
  private readonly object lockObject = new object();
  private bool wasNHibernateInitialized;
    
  private void Application_BeginRequest(object sender, EventArgs e)
  {
    InitializeNHibernate();
  }
  
  private void Application_EndRequest(object sender, EventArgs e)
  {
    NHibernateSessionStorage.DisposeCurrent();
  }
  
  private void InitializeNHibernate()
  {
    if (!wasNHibernateInitialized) 
    {
      lock (lockObject) 
      {
        if (!wasNHibernateInitialized) 
        {
          NHibernateConfiguration.Init(
              MsSqlConfiguration.MsSql2005.
              ConnectionString(builder => builder.
              FromConnectionStringWithKey("ApplicationServices")), 
              UpdateDatabase()); 
  
          wasNHibernateInitialized = true;
        }
      }
    }
  }
  
  private Action<Configuration> UpdateDatabase()
  {
      return config => new SchemaUpdate(config).Execute(false, true);
  }
}
public class MvcApplication : HttpApplication
{
  //omit NHibernateConfiguration code...
  
  protected void Application_Start()
  {
    SetupWindsorContainer();
    RegisterRoutes(RouteTable.Routes);
  }
  
  private void SetupWindsorContainer() 
  {
    IWindsorContainer container = new WindsorContainer();
  
    RegisterControllers(container);
    RegisterNHibernateSessionFactory(container);
    RegisterRepositories(container);
  }
    
  private void RegisterControllers(IWindsorContainer container)
  {
    ControllerBuilder.Current. 
      SetControllerFactory(new WindsorControllerFactory(container));
    container.RegisterControllers(typeof (HomeController).Assembly); 
  }
}
private void RegisterNHibernateSessionFactory(
  IWindsorContainer container)
{
  container.AddFacility<FactorySupportFacility>(); 
  container.Register(Component.For<ISession>(). 
    UsingFactoryMethod(() => 
    NHibernateSessionStorage.RetrieveSession()).
    LifeStyle.Is(LifestyleType.Transient)); 
}
private void RegisterRepositories(IWindsorContainer container)
{
  IEnumerable<Type> repositories = Assembly.GetExecutingAssembly().
    GetTypes().Where(IsRepository); 

  foreach (Type repository in repositories)
  {
    container.AddComponentLifeStyle(repository.Name, repository,
      LifestyleType.Transient); 
  }
}

private bool IsRepository(Type type)
{
  return type.Namespace != null && type.IsClass && !type.IsAbstract && 
    type.Namespace.Contains("GetOrganized.Persistence.Repositories");
}
protected void Application_Start()
{
  SetupWindsorContainer();
  RegisterRoutes(RouteTable.Routes);
  
  HibernatingRhinos.NHibernate.Profiler.
    Appender.NHibernateProfiler.Initialize(); 
}
