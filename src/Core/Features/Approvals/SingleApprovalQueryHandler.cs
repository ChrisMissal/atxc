namespace Core.Features.Approvals
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Transform;

    public class SingleApprovalQueryHandler : IAsyncRequestHandler<SingleApprovalQuery, ApprovalSummary>
    {
        private readonly ISession _session;

        public SingleApprovalQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<ApprovalSummary> Handle(SingleApprovalQuery message)
        {
            return Task.Factory.StartNew(() => _session.Query<Approval>()
                .Where(x => x.Slug == message.Id)
                .Select(x => new ApprovalSummary
                {
                    Slug = x.Slug,
                })
                .SingleOrDefault());
        }
    }
}