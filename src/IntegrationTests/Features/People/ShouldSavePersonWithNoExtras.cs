namespace IntegrationTests.Features.People
{
    using Core.Entities;
    using Core.Enumeration;
    using Core.Features.People;
    using NHibernate;
    using Shouldly;

    public class ShouldSavePersonWithNoExtras
    {
        private readonly int _personId;

        public ShouldSavePersonWithNoExtras(ISession session, PersonFactory personFactory)
        {
            var person = personFactory.CreatePerson("first last", "blarg@test.com", "this is my bio", Location.Austin);
            session.SaveOrUpdate(person);
            _personId = person.Id;
        }

        public void Name_should_be_expected(ISession session)
        {
            var person = session.Get<Person>(_personId);

            person.Name.ShouldBe("first last");
        }
    }
}
