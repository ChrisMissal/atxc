namespace UI
{
    using System.Web.Http;
    using AutoMapper;
    using Controllers;
    using Core.Entities;
    using FluentValidation;
    using MediatR;
    using Microsoft.Practices.ServiceLocation;
    using Resolvers;
    using StructureMap;

    public static class Bootstrapper
    {
        public static IContainer BootstrapApplication(HttpConfiguration config)
        {
            var container = new Container(cfg => cfg.Scan(scanner =>
            {
                scanner.Assembly(typeof(Person).Assembly);
                scanner.Assembly(typeof(BaseController).Assembly);
                scanner.AssemblyContainingType<IMediator>();
                scanner.WithDefaultConventions();
                scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IPostRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IAsyncPostRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(INotificationHandler<>));
                scanner.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
                scanner.AddAllTypesOf<Profile>();
                scanner.AddAllTypesOf(typeof(IValidator<>));
                scanner.LookForRegistries();
            }));

            var serviceLocator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);
            container.Configure(cfg => cfg.For<ServiceLocatorProvider>().Use(serviceLocatorProvider));

            config.DependencyResolver = new StructureMapResolver(container);

            return container;
        }

        public static void ValidateApplication()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}