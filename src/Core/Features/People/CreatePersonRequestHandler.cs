namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;

    public class CreatePersonRequestHandler : IAsyncRequestHandler<CreatePersonRequest, Person>
    {
        private readonly ISession _session;
        private readonly IMediator _mediator;

        public CreatePersonRequestHandler(ISession session, IMediator mediator)
        {
            _session = session;
            _mediator = mediator;
        }

        public Task<Person> Handle(CreatePersonRequest message)
        {
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
                    Slug = message.Name.ToSlug(),
                };
                _session.SaveOrUpdate(person);
                _mediator.PublishAsync(new PersonCreatedNotification(person.Id));
                return person;
            });
        }
    }
}