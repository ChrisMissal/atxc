namespace DataLoader.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Entities;
    using Core.Enumeration;
    using Generators;
    using NHibernate;
    using Ploeh.AutoFixture;

    internal class PersonLoader : Loader<Person>
    {
        private static readonly int[] PersonalNumberOfCategories = { 1, 1, 1, 2, 2, 2, 2, 3, 4, 5 };

        private readonly EnumerationGenerator<Category> _categoryGenerator = new EnumerationGenerator<Category>();

        public PersonLoader(LoaderConfig config, Fixture fixture, ISession session) : base(config, fixture, session)
        {
        }

        protected override object Create()
        {
            var person = _fixture.Build<Person>()
                                     .Without(x => x.ImageUrl)
                                     .Without(x => x.Deleted)
                                     .Without(x => x.Slug)
                                     .Do(x => x.AddCategories(GetRandomCategories().ToList()))
                                     .Create();

            person.Slug = person.Name.ToSlug();

            return person;
        }

        private IEnumerable<CategoryField> GetRandomCategories()
        {
            var categoryCount = PersonalNumberOfCategories.ElementAt(new Random().Next(PersonalNumberOfCategories.Length));
            for (var i = 0; i < categoryCount; i++)
            {
                var category = _categoryGenerator.GetRandom();
                yield return new CategoryField { Value = category.Value };
            }
        }
    }
}