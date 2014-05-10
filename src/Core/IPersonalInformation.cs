namespace Core
{
    using System.Collections.Generic;
    using Enumeration;

    public interface IPersonalInformation : IEntity
    {
        string Name { get; }

        string Bio { get; }

        string Email { get; }

        Location Location { get; }

        List<Link> Links { get; }

        List<Category> Categories { get; }
    }
}