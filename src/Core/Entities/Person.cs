namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using Enumeration;

    public class Person : IEntity, IDeletable, IHaveEmail
    {
        public Person()
        {
            Links = new List<LinkField>();
            Categories = new List<CategoryField>();
        }

        public virtual int Id { get; protected set; }

        public virtual string Slug { get; set; }

        public virtual string Name { get; set; }

        public virtual string Bio { get; set; }

        public virtual string Email { get; set; }

        public virtual Location Location { get; set; }

        public virtual IList<LinkField> Links { get; protected set; }

        public virtual IList<CategoryField> Categories { get; protected set; }

        public virtual DateTime Joined { get; set; }

        public virtual DateTime? Approved { get; set; }

        public virtual DateTime? Deleted { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual void AddCategories(IList<CategoryField> categories)
        {
            Categories.TryAddRange(categories, this);
        }

        public virtual void RemoveCategory(CategoryField category)
        {
            if (Categories.Contains(category))
                category.Deleted = SystemClock.UtcNow;
        }

        public virtual void AddLinks(IEnumerable<LinkField> links)
        {
            Links.TryAddRange(links, this);
        }

        public virtual void RemoveLink(LinkField link)
        {
            if (Links.Contains(link))
                link.Deleted = SystemClock.UtcNow;
        }
    }
}
