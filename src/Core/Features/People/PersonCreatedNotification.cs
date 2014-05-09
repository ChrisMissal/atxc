namespace Core.Features.People
{
    using System;
    using MediatR;

    public class PersonCreatedNotification : IAsyncNotification
    {
        public PersonCreatedNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}