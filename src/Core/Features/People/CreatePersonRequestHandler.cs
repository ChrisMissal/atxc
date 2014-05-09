namespace Core.Features.People
{
    using System.Threading.Tasks;
    using MediatR;

    public class CreatePersonRequestHandler : IAsyncRequestHandler<CreatePersonRequest, IPersonalInformation>
    {
        private readonly IMediator _mediator;

        public CreatePersonRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IPersonalInformation> Handle(CreatePersonRequest message)
        {
            // todo: create a person
            return Task.Factory.StartNew(() =>
            {
                var person = (IPersonalInformation) message;
                _mediator.PublishAsync(new PersonCreatedNotification(person.Id));
                return person;
            });
        }
    }
}