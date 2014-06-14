namespace Core.Features.People
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Transform;

    public class RandomPersonQueryHandler : IAsyncRequestHandler<RandomPersonQuery, PersonSummary>
    {
        private readonly ISession _session;

        public RandomPersonQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<PersonSummary> Handle(RandomPersonQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var people = _session.Query<Person>()
                    .OrderBy(x => x.Random)
                    .Select(x => new PersonSummary
                    {
                        Name = x.Name,
                        Slug = x.Slug,
                        Email = x.Email,
                    })
                    .Take(1)
                    .First();

                return people;
            });
        }
    }
}