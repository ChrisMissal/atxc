namespace UI.Transactions
{
    using Core.Data;
    using NHibernate;
    using StructureMap.Configuration.DSL;
    using StructureMap.Web;

    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            For<ISessionFactory>().Singleton().Use(new ConfigurationFactory(DatabaseSettings.Default).GetSessionFactory());
            For<ISession>().HybridHttpOrThreadLocalScoped().Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}