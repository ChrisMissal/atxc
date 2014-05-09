namespace Core.Features.People
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using Enumeration;
    using MediatR;

    public class CreatePersonRequest : IAsyncRequest<Person>, IPersonalInformation
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Bio { get; private set; }

        public string Email { get; private set; }

        public Location Location { get; private set; }

        public List<Link> Links { get; private set; }

        public List<Category> Categories { get; private set; }
    }
}