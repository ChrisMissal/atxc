namespace IntegrationTests.Features.People
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Enumeration;
    using Core.Features.People;
    using NHibernate;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using Shouldly;
    using StructureMap;

    public class ShouldSavePersonWithCategoriesRemoved : IDisposable
    {
        private readonly IContainer _container;

        private readonly int _personId;
        private const int _startCount = 3;
        private const int _removedCount = 2;

        public ShouldSavePersonWithCategoriesRemoved(ISession session, PersonFactory personFactory, ISpecimenBuilder specimenBuilder, IContainer container)
        {
            _container = container;
            var categories = specimenBuilder.CreateMany<CategoryField>(_startCount).ToList();
            var fake = specimenBuilder.Create<Person>();
            var person = personFactory.CreatePerson(fake.Name, fake.Email, fake.Bio, Location.SanMarcos, categories);
            session.SaveOrUpdate(person);
            _personId = person.Id;
        }

        public void Person_should_have_and_remove_some_Categories(ISession session)
        {
            var person = session.Get<Person>(_personId);

            person.Categories.Count.ShouldBe(_startCount);

            person.RemoveCategory(person.Categories.First());
            person.RemoveCategory(person.Categories.Last());

            session.SaveOrUpdate(person);
        }

        public void Dispose()
        {
            var session = _container.GetInstance<ISession>();

            var person = session.Get<Person>(_personId);

            person.Categories.Count.ShouldBe(_startCount - _removedCount);
        }
    }
}