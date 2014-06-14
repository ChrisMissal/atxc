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

    public class PeopleByCategoryQueryHandler : IAsyncRequestHandler<PeopleByCategoryQuery, PeopleCollection<Category>>
    {
        private readonly ISession _session;

        public PeopleByCategoryQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<PeopleCollection<Category>> Handle(PeopleByCategoryQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var people = _session.Query<CategoryField>()
                    .Where(x => x.Value == message.Category.Value)
                    .Select(x => new PersonSummary
                    {
                        Name = x.Person.Name,
                        Slug = x.Person.Slug,
                        Email = x.Person.Email,
                    })
                    .Take(100)
                    .ToList();

                return new PeopleCollection<Category>(message.Category)
                {
                    People = people
                };
            });
        }
    }
}