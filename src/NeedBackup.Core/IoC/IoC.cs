using System;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions;
using NHibernate;
using NHibernate.Cfg;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using Environment = NHibernate.Cfg.Environment;

namespace NeedBackup.Core.IoC
{
    public static class IoC
    {
        private static Container _container;

        public static Container Container => _container ?? (_container = SetUpContainer());

        private static Container SetUpContainer()
        {
            return new Container(x => x.AddRegistry(new NhibernateRegistry()));
        }
    }

    internal class NhibernateRegistry : Registry
    {
        public NhibernateRegistry()
        {
            var config =
                new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));
            config.SetProperty(Environment.ConnectionStringName, System.Environment.MachineName + "_mysql");

            var factory = Fluently.Configure(config)
                .Mappings(
                    x =>
                        x.FluentMappings.AddFromAssembly(Assembly.Load("NeedBackup.Core"))
                            .Conventions.Add(new TablenameConvention()))
                            .BuildSessionFactory();

            For<ISessionFactory>().Singleton().Use(factory);
            For<ISession>()
                .LifecycleIs(new ThreadLocalStorageLifecycle())
                .Use(x => x.GetInstance<ISessionFactory>().OpenSession());
        }
    }

    public class TablenameConvention : IConvention
    {
        public TablenameConvention()
        {
            
        }
    }
}