namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
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
            return Task.Factory.StartNew(() =>
            {
                const string sql = @"select top 1
                                        [Name]
                                     ,  [Slug]
                                     ,  [Email]
                                     from PersonView p
                                     where p.Slug = :id";

                return _session.CreateSQLQuery(sql)
                    .SetString("id", message.Id)
                    .SetResultTransformer(Transformers.AliasToBean<PersonSummary>())
                    .UniqueResult<PersonSummary>();
            });
        }
    }
}