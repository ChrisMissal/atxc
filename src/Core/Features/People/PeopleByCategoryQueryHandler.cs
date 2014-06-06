namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using Enumeration;
    using MediatR;
    using NHibernate;
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
                const string sql = @"select top 100
                                        [Name]
                                     ,  [Slug]
                                     ,  [Email]
                                     from PersonCategoryView
                                     where [Category] = :category";

                var people = _session.CreateSQLQuery(sql)
                    .SetParameter("category", message.Category.Value)
                    .SetResultTransformer(Transformers.AliasToBean<PersonSummary>())
                    .List<PersonSummary>();

                return new PeopleCollection<Category>(message.Category)
                {
                    People = people
                };
            });
        }
    }
}