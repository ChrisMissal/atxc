namespace Core.Features.People
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;

    public class CreatePersonRequestHandler : IAsyncRequestHandler<CreatePersonRequest, Person>
    {
        private readonly IMediator _mediator;

        public CreatePersonRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Person> Handle(CreatePersonRequest message)
        {
            // todo: create a person
            return Task.Factory.StartNew(() =>
            {
                var person = new Person
                {
                    Bio = message.Bio,
                    Categories = message.Categories,
                    Email = message.Email,
                    Joined = SystemClock.UtcNow,
                    Links = message.Links,
                    Location = message.Location,
                    Name = message.Name,
                };
                _mediator.PublishAsync(new PersonCreatedNotification(person.Id));
                return person;
            });
        }
    }
}