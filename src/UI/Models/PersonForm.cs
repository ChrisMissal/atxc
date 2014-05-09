namespace UI.Models
{
    using System;
    using System.Collections.Generic;

    public class PersonForm
    {
        public virtual Guid Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual string Bio { get; set; }

        public virtual string Email { get; set; }

        public virtual string Location { get; set; }

        public virtual List<string> Links { get; set; }

        public virtual List<string> Categories { get; set; }
    }
}