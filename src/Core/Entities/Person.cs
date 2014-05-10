namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using Enumeration;

    public class Person : ILinkable, IPersonalInformation
    {
        private string _personId;

        public virtual int Id { get; protected set; }

        public virtual string Slug { get; set; }

        public virtual string Name { get; set; }

        public virtual string Bio { get; set; }

        public virtual string Email { get; set; }

        public virtual Location Location { get; set; }

        public virtual List<Link> Links { get; set; }

        public virtual List<Category> Categories { get; set; }

        public virtual DateTime Joined { get; set; }

        public virtual DateTime? Approved { get; set; }

        public virtual string Url
        {
            get { return string.Format("#/profile/{0}", Name.ToSlug()); }
        }

        public virtual string ImageUrl { get; set; }
    }
}
