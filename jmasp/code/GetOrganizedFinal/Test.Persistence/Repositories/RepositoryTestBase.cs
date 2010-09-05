/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using FluentNHibernate.Cfg.Db;
using GetOrganized.Persistence;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Test.Persistence.Repositories
{
    public class RepositoryTestBase
    {
        protected ISession session;

        [SetUp]
        public void setup()
        {
            NHibernateConfiguration.Init(
                MsSqlConfiguration.MsSql2005.ConnectionString(
                    builder => 
                    builder.Server("localhost").
                        Database("test_GetOrganized").
                        TrustedConnection()), 
                RebuildDatabase());
           

            session = NHibernateConfiguration.CreateAndOpenSession();
            
        }

        [TearDown]
        public void teardown()
        {
            if (session != null) session.Dispose();
        }

        private Action<Configuration> RebuildDatabase()
        {
            return config => new SchemaExport(config).Create(false, true);
        }
    }
}