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

        public async Task<IList<Person>> Get()
        {
            return await _mediator.SendAsync(new PersonQuery());
        }

        public async Task<Person> Get(string id)
        {
            var person = await _mediator.SendAsync(new SinglePersonQuery(id));
            person.ImageUrl = person.GetImageUrl();
            return person;
        }

        [ValidationResponseFilter]
        public async Task<Person> Post(PersonForm form)
        {
            var request = Mapper.Map<CreatePersonRequest>(form);
            var person = await _mediator.SendAsync(request);
            person.ImageUrl = person.GetImageUrl();
            return person;
        }
    }
}