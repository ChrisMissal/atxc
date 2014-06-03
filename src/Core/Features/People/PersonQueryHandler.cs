namespace Core.Features.People
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;

    public class PersonQueryHandler : IAsyncRequestHandler<PersonQuery, List<PersonSummary>>
    {
        public Task<List<PersonSummary>> Handle(PersonQuery message)
        {
            return Task.Factory.StartNew(() => new List<PersonSummary>());
        }
    }
}