using System;
using System.Collections.Generic;
using Core.Enumeration;
using Raven.Imports.Newtonsoft.Json;

namespace Core
{
    public class Person : ILinkable, IPersonalInformation
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual string Bio { get; set; }

        public virtual string Email { get; set; }

        public virtual Location Location { get; set; }

        public virtual List<Link> Links { get; set; }

        public virtual List<Category> Categories { get; set; }

        public virtual DateTime Joined { get; set; }

        public virtual DateTime? Approved { get; set; }

        [JsonIgnore]
        public string Url
        {
            get { return string.Format("#/profile/{0}", Name.ToSlug()); }
        }

        public string PersonId
        {
            get { return Name.ToSlug(); }
        }
    }
}
