namespace UI.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Entities;
    using Core.Features.People;
    using MediatR;
    using Models;
    using Validation;

    public class PersonController : BaseController
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PersonSummary> Get()
        {
            var person = await _mediator.SendAsync(new RandomPersonQuery());

            return person;
        }

        public async Task<PersonSummary> Get(string id)
        {
            var request = new SinglePersonQuery { Id = id };
            var person = await _mediator.SendAsync(request);

            person.ImageUrl = person.GetImageUrl();

            return person;
        }

        [ValidationResponseFilter]
        public async Task<PersonSummary> Post(PersonForm form)
        {
            var request = Mapper.Map<CreatePersonRequest>(form);
            var person = await _mediator.SendAsync(request);
            _mediator.PublishAsync(new PersonCreatedNotification(person.Id));

            return Mapper.Map<PersonSummary>(person);
        }
    }
}