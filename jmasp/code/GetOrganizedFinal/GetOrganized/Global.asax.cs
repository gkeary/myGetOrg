/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core;
using Castle.Facilities.FactorySupport;
using Castle.Windsor;
using FluentNHibernate.Cfg.Db;
using GetOrganized.Controllers;
using GetOrganized.Gateway;
using GetOrganized.Persistence;
using HibernatingRhinos.NHibernate.Profiler.Appender;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Component=Castle.MicroKernel.Registration.Component;

namespace GetOrganized
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private readonly object lockObject = new object();
        private bool wasNHibernateInitialized;


        protected void Application_Start()
        {
            SetupWindsorContainer();

            NHibernateProfiler.Initialize();

            RegisterRoutes(RouteTable.Routes);
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            InitializeNHibernate();
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            NHibernateSessionStorage.DisposeCurrent();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Formattable", "{controller}/{action}/{format}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
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
                                ConnectionString(builder =>
                                                 builder.
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

        protected virtual void SetupWindsorContainer()
        {
            IWindsorContainer container = new WindsorContainer();

            RegisterControllers(container);
            RegisterNHibernateSessionFactory(container);
            RegisterRepositories(container);
            RegisterGateways(container);
        }

        private static void RegisterControllers(IWindsorContainer container)
        {
            ControllerBuilder.Current.
                SetControllerFactory(new WindsorControllerFactory(container));
            container.RegisterControllers(typeof (HomeController).Assembly);
        }

        private static void RegisterNHibernateSessionFactory(IWindsorContainer container)
        {
            container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<ISession>().
                                   UsingFactoryMethod(() =>
                                                      NHibernateSessionStorage.RetrieveSession()).
                                   LifeStyle.Is(LifestyleType.Transient));
        }

        private static void RegisterRepositories(IWindsorContainer container)
        {
            IEnumerable<Type> repositories = Assembly.GetExecutingAssembly().
                GetTypes().Where(IsRepository);

            foreach (Type repository in repositories)
            {
                container.AddComponentLifeStyle(repository.Name, repository,
                  LifestyleType.Transient);
            }
        }

        private static bool IsRepository(Type type)
        {
            return type.Namespace != null && type.IsClass && !type.IsAbstract &&
                   type.Namespace.Contains("GetOrganized.Persistence.Repositories");
        }

        private static void RegisterGateways(IWindsorContainer container)
        {
            container.AddComponentLifeStyle("bloggerGateway",
            typeof(BloggerGateway), LifestyleType.Transient);
        }
    }
}