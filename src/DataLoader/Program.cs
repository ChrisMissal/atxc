namespace DataLoader
{
    using Core.Data;
    using Core.Enumeration;
    using Ploeh.AutoFixture;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoaderConfig(args);

            var factory = new ConfigurationFactory();
            var sessionFactory = factory.GetSessionFactory();

            var fixture = new Fixture();
            fixture.Customizations.Add(new EnumerationGenerator<Location>());

            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                tran.Begin();

                new PersonLoader(config, fixture, session).Load(150);

                tran.Commit();
            }
        }
    }
}
