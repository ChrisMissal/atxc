namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;

    public class CreatePersonRequestHandler : IAsyncRequestHandler<CreatePersonRequest, Person>
    {
        private readonly ISession _session;
        private readonly PersonFactory _personFactory;

        public CreatePersonRequestHandler(ISession session, PersonFactory personFactory)
        {
            _session = session;
            _personFactory = personFactory;
        }

        public Task<Person> Handle(CreatePersonRequest message)
        {
            return Task.Factory.StartNew(() =>
            {
                var person = _personFactory.CreatePerson(message.Name, message.Email, message.Bio, message.Location, message.Categories, message.Links);

                _session.SaveOrUpdate(person);

                return person;
            });
        }
    }
}