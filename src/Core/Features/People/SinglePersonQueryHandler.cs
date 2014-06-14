namespace Core.Features.People
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Transform;

    public class SinglePersonQueryHandler : IAsyncRequestHandler<SinglePersonQuery, PersonSummary>
    {
        private readonly ISession _session;

        public SinglePersonQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<PersonSummary> Handle(SinglePersonQuery message)
        {
            return Task.Factory.StartNew(() => _session.Query<Person>()
                .Select(x => new PersonSummary
                {
                    Name = x.Name,
                    Slug = x.Slug,
                    Email = x.Email,
                })
                .SingleOrDefault(x => x.Slug == message.Id));
        }
    }
}