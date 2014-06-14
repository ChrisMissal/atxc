namespace Core.Features.People
{
    using System.Collections.Generic;
    using Entities;
    using Enumeration;

    public class PersonFactory
    {
        public Person CreatePerson(string name, string email, string bio, Location location, ICollection<CategoryField> categories = null, ICollection<LinkField> links = null)
        {
            var person = new Person
            {
                Bio = bio,
                Email = email,
                Joined = SystemClock.UtcNow,
                Location = location,
                Name = name,
                Slug = name.ToSlug(),
            };
            if (categories != null && categories.Count > 0)
            {
                person.AddCategories(categories);
            }
            if (links != null && links.Count > 0)
            {
                person.AddLinks(links);
            }
            return person;
        }
    }
}