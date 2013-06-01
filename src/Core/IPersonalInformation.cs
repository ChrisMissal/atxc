using System.Collections.Generic;
using Core.Enumeration;

namespace Core
{
    public interface IPersonalInformation
    {
        string Name { get; }

        string Bio { get; }

        string Email { get; }

        Location Location { get; }

        List<Link> Links { get; }

        List<Category> Categories { get; }
    }
}