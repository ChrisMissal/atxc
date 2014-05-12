namespace Core.Features.People
{
    using System.Collections.Generic;
    using Entities;
    using Enumeration;
    using MediatR;

    public class CreatePersonRequest : IAsyncRequest<Person>, IEntity
    {
        public int Id { get; private set; }

        public string Slug { get; private set; }

        public string Name { get; private set; }

        public string Bio { get; private set; }

        public string Email { get; private set; }

        public Location Location { get; private set; }

        public List<LinkField> Links { get; private set; }

        public List<CategoryField> Categories { get; private set; }
    }
}