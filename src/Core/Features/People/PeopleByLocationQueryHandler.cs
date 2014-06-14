namespace Core.Features.People
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Enumeration;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Transform;

    public class PeopleByLocationQueryHandler : IAsyncRequestHandler<PeopleByLocationQuery, PeopleCollection<Location>>
    {
        private readonly ISession _session;

        public PeopleByLocationQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<PeopleCollection<Location>> Handle(PeopleByLocationQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var people = _session.Query<Person>()
                    .Where(x => x.Location == message.Location)
                    .Select(x => new PersonSummary
                    {
                        Name = x.Name,
                        Slug = x.Slug,
                        Email = x.Email,
                    })
                    .Take(100)
                    .ToList();

                return new PeopleCollection<Location>(message.Location)
                {
                    People = people
                };
            });
        }
    }
}