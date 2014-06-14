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

    public class ShouldSavePersonWithCategories
    {
        private readonly int _personId;
        private const int _count = 4;

        public ShouldSavePersonWithCategories(ISession session, PersonFactory personFactory, ISpecimenBuilder specimenBuilder)
        {
            var categories = specimenBuilder.CreateMany<CategoryField>(_count).ToList();
            var fake = specimenBuilder.Create<Person>();
            var person = personFactory.CreatePerson(fake.Name, fake.Email, fake.Bio, Location.SanMarcos, categories);
            session.SaveOrUpdate(person);
            _personId = person.Id;
        }

        public void Person_should_have_several_Categories(ISession session)
        {
            var person = session.Get<Person>(_personId);

            person.Categories.Count.ShouldBe(_count);
        }
    }
}