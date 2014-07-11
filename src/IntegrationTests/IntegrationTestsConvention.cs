namespace IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Core.Data;
    using Fixie;
    using NHibernate;
    using StructureMap;

    public class IntegrationTestsConvention : Fixie.Conventions.Convention
    {
        private readonly IContainer _container;

        public IntegrationTestsConvention()
        {
            _container = new Container(s => s.AddRegistry<IntegrationTestRegistry>());

            Classes
                .Where(TestClassMatcher);

            Methods
                .Where(method => method.IsVoid());

            ClassExecution
                .CreateInstancePerClass()
                .UsingFactory(t => _container.GetInstance(t));

            CaseExecution
                .Wrap(CommitBeforeTestCase);

            Parameters(GetMethodParameters);
        }

        private void CommitBeforeTestCase(CaseExecution caseexecution, object instance, Action innerbehavior)
        {
            var session = _container.GetInstance<ISession>();
            session.Flush();
            session.Clear();

            innerbehavior();
        }

        private static bool TestClassMatcher(Type arg)
        {
            if (!arg.IsInNamespace("IntegrationTests"))
                return false;

            return (arg.Name.EndsWith("Tests") || arg.Name.StartsWith("Should"));
        }

        private IEnumerable<object[]> GetMethodParameters(MethodInfo arg)
        {
            return arg.GetParameters().Select(parameter => new[]
                {
                    GetInstance(parameter)
                });
        }

        private object GetInstance(ParameterInfo parameter)
        {
            var instance = _container.GetInstance(parameter.ParameterType);
            if (instance is ISession)
            {
                var session = instance as ISession;
                var databaseSettings = _container.GetInstance<DatabaseSettings>();
                session.EnableFilter("tenant").SetParameter("TenantId", databaseSettings.TenantId);
            }
            return instance;
        }
    }
}
