/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.Core;
using Castle.Windsor;
using MvcContrib;

namespace GetOrganized.Persistence
{
    public static class WindsorExtensions
    {
        public static IWindsorContainer RegisterController<T>(this IWindsorContainer container) where T : IController
        {
            container.RegisterControllers(typeof (T));
            return container;
        }

        public static IWindsorContainer RegisterControllers(this IWindsorContainer container,
                                                            params Type[] controllerTypes)
        {
            foreach (Type type in controllerTypes)
            {
                if (ControllerExtensions.IsController(type))
                {
                    container.AddComponentLifeStyle(type.FullName.ToLower(), type, LifestyleType.Transient);
                }
            }

            return container;
        }

        public static IWindsorContainer RegisterControllers(this IWindsorContainer container,
                                                            params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                container.RegisterControllers(assembly.GetExportedTypes());
            }
            return container;
        }
    }
}