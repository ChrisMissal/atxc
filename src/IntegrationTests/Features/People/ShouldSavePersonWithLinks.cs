namespace IntegrationTests.Features.People
{
    using System.Linq;
    using Core.Entities;
    using Core.Enumeration;
    using Core.Features.People;
    using NHibernate;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using Shouldly;

    public class ShouldSavePersonWithLinks
    {
        private readonly int _personId;
        private const int _count = 6;

        public ShouldSavePersonWithLinks(ISession session, PersonFactory personFactory, ISpecimenBuilder specimenBuilder)
        {
            var links = specimenBuilder.CreateMany<LinkField>(_count).ToList();
            var fake = specimenBuilder.Create<Person>();
            var person = personFactory.CreatePerson(fake.Name, fake.Email, fake.Bio, Location.Georgetown, null, links);
            session.SaveOrUpdate(person);
            _personId = person.Id;
        }

        public void Person_should_have_several_Links(ISession session)
        {
            var person = session.Get<Person>(_personId);

            person.Links.Count.ShouldBe(_count);
        }
    }
}