namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using Enumeration;
    using MediatR;
    using NHibernate;
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
                const string sql = @"select top 100
                                        [Name]
                                     ,  [Slug]
                                     ,  [Email]
                                     from PersonView
                                     where [Location] = :location";

                var people = _session.CreateSQLQuery(sql)
                    .SetParameter("location", message.Location.Value)
                    .SetResultTransformer(Transformers.AliasToBean<PersonSummary>())
                    .List<PersonSummary>();

                return new PeopleCollection<Location>(message.Location)
                {
                    People = people
                };
            });
        }
    }
}