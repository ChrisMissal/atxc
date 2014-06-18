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

    public class ShouldSavePersonWithLinksRemoved : IDisposable
    {
        private readonly IContainer _container;

        private readonly int _personId;
        private const int _startCount = 3;
        private const int _removedCount = 2;

        public ShouldSavePersonWithLinksRemoved(ISession session, PersonFactory personFactory, ISpecimenBuilder specimenBuilder, IContainer container)
        {
            _container = container;
            var links = specimenBuilder.CreateMany<LinkField>(_startCount).ToList();
            var fake = specimenBuilder.Create<Person>();
            var person = personFactory.CreatePerson(fake.Name, fake.Email, fake.Bio, Location.SanMarcos, null, links);
            session.SaveOrUpdate(person);
            _personId = person.Id;
        }

        public void Person_should_have_and_remove_some_Links(ISession session)
        {
            var person = session.Get<Person>(_personId);

            person.Links.Count.ShouldBe(_startCount);

            person.RemoveLink(person.Links.First());
            person.RemoveLink(person.Links.Last());

            session.SaveOrUpdate(person);
        }

        public void Dispose()
        {
            var session = _container.GetInstance<ISession>();

            var person = session.Get<Person>(_personId);

            person.Links.Count.ShouldBe(_startCount - _removedCount);
        }
    }
}