namespace Core.Features.People
{
    using Entities;
    using Enumeration;
    using MediatR;

    public class PeopleByLocationQuery : IAsyncRequest<PeopleCollection<Location>>
    {
        public Location Location { get; set; }
    }
}