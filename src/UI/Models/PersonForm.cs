namespace UI.Models
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Core.Entities;
    using Core.Enumeration;

    public class PersonForm : IPersonalInformation
    {
        public virtual Guid Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual string Bio { get; set; }

        public virtual string Email { get; set; }

        public virtual Location Location { get; set; }

        public virtual List<Link> Links { get; set; }

        public virtual List<Category> Categories { get; set; }

        public Person ToPerson()
        {
            return new Person
            {
                Name = Name,
                Bio = Bio,
                Email = Email,
                Location = Location,
                Links = Links,
                Categories = Categories,

                Joined = SystemClock.UtcNow,
            };
        }
    }
}