namespace UI.Controllers
{
    using System.Collections.Generic;
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

        public async Task<IList<PersonSummary>> Get()
        {
            var people = await _mediator.SendAsync(new PersonQuery());

            return Mapper.Map<List<PersonSummary>>(people);
        }

        public async Task<PersonSummary> Get(string id)
        {
            var person = await _mediator.SendAsync(new SinglePersonQuery(id));

            person.ImageUrl = person.GetImageUrl();

            return person;
        }

        [ValidationResponseFilter]
        public async Task<PersonSummary> Post(PersonForm form)
        {
            var request = Mapper.Map<CreatePersonRequest>(form);
            var person = await _mediator.SendAsync(request);

            return Mapper.Map<PersonSummary>(person);
        }
    }
}