namespace UI.Controllers
{
    using System.Threading.Tasks;
    using Core;
    using Core.Entities;
    using Core.Enumeration;
    using Core.Features.People;
    using MediatR;

    public class LocationController : EnumerationController<Location>
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PeopleCollection<Location>> Get(string id)
        {
            var location = Location.FromValue(id);
            var query = new PeopleByLocationQuery { Location = location };
            var collection = await _mediator.SendAsync(query);

            collection.People.ForEach(p => { p.ImageUrl = p.GetImageUrl(); });

            return collection;
        }
    }
}