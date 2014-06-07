namespace IntegrationTests
{
    using Fixie;
    using NHibernate;
    using Ploeh.AutoFixture;
    using StructureMap;

    public class IntegrationTestsConvention : Fixie.Conventions.DefaultConvention
    {
        private readonly IContainer _container;
        private ISession _session;

        public IntegrationTestsConvention()
        {
            _container = new Container(s => s.AddRegistry<IntegrationTestRegistry>());

            Classes
                .Where(type => type.IsInNamespace("IntegrationTests"))
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            ClassExecution
                .CreateInstancePerClass()
                .UsingFactory(t => _container.GetNestedContainer().GetInstance(t))
                .SetUpTearDown(SetUp, TearDown);
        }

        private void SetUp(ClassExecution obj)
        {
            _session = _container.GetInstance<ISession>();
        }

        private void TearDown(ClassExecution obj)
        {
            _session.Flush();
        }
    }
}
