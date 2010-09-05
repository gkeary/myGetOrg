/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System.Web;
using NHibernate;

namespace GetOrganized.Persistence
{
    public class NHibernateSessionStorage
    {
        private const string CURRENT_SESSION_KEY = "nhibernate.current_session";

        public static ISession RetrieveSession()
        {
            HttpContext context = HttpContext.Current;
            if (!context.Items.Contains(CURRENT_SESSION_KEY)) OpenCurrent();
            var session = context.Items[CURRENT_SESSION_KEY] as ISession;
            return session;
        }

        private static void OpenCurrent()
        {
            ISession session = NHibernateConfiguration.CreateAndOpenSession();
            HttpContext context = HttpContext.Current;
            context.Items[CURRENT_SESSION_KEY] = session;
        }

        public static void DisposeCurrent()
        {
            if (!HttpContext.Current.Items.Contains(CURRENT_SESSION_KEY)) return;

            ISession session = RetrieveSession();
            if (session != null && session.IsOpen)
                session.Close();
            HttpContext context = HttpContext.Current;
            context.Items.Remove(CURRENT_SESSION_KEY);
        }

        public static ITransaction Transaction
        {
            get { return RetrieveSession().Transaction; }
        }
    }
}