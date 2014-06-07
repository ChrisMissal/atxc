namespace Core.Features.Approvals
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Transform;

    public class SingleApprovalQueryHandler : IAsyncRequestHandler<SingleApprovalQuery, ApprovalSummary>
    {
        private ISession _session;

        public SingleApprovalQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<ApprovalSummary> Handle(SingleApprovalQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                const string sql = @"select top 1 newid() [Id]";

                var approval = _session.CreateSQLQuery(sql)
                    .SetResultTransformer(Transformers.AliasToBean<ApprovalSummary>())
                    .UniqueResult<ApprovalSummary>();

                return approval;
            });
        }
    }
}