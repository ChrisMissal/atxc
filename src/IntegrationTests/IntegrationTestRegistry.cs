namespace IntegrationTests
{
    using Core.Data;
    using Core.Entities;
    using MediatR;
    using NHibernate;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using StructureMap.Configuration.DSL;

    public class IntegrationTestRegistry : Registry
    {
        public IntegrationTestRegistry()
        {
            Scan(scanner =>
            {
                scanner.Assembly(typeof(Person).Assembly);
                scanner.AssemblyContainingType<IMediator>();
                scanner.WithDefaultConventions();
                scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IPostRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IAsyncPostRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(INotificationHandler<>));
                scanner.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
            });

            For<ISpecimenBuilder>().Singleton().Use(() => new Fixture());

            For<ISessionFactory>().Singleton().Use(new ConfigurationFactory().GetSessionFactory());
            For<ISession>().Singleton().Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}