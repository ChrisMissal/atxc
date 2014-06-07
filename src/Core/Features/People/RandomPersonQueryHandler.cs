namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
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
                const string sql = @"select top 1
                                        [Name]
                                     ,  [Slug]
                                     ,  [Email]
                                     from PersonView p
                                     order by newid()";

                return _session.CreateSQLQuery(sql)
                    .SetResultTransformer(Transformers.AliasToBean<PersonSummary>())
                    .UniqueResult<PersonSummary>();
            });
        }
    }
}