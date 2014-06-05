namespace DataLoader.Loaders
{
    using Core;
    using Core.Entities;
    using NHibernate;
    using Ploeh.AutoFixture;

    internal class PersonLoader : Loader<Person>
    {
        public PersonLoader(LoaderConfig config, Fixture fixture, ISession session) : base(config, fixture, session)
        {
        }

        protected override object Create()
        {
            var person = _fixture.Build<Person>()
                                     .Without(x => x.ImageUrl)
                                     .Without(x => x.Deleted)
                                     .Without(x => x.Slug)
                                     .Create();

            person.Slug = person.Name.ToSlug();

            return person;
        }
    }
}