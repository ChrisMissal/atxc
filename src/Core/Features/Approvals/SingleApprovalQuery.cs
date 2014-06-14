namespace Core.Features.Approvals
{
    using Entities;
    using MediatR;

    public class SingleApprovalQuery : IAsyncRequest<ApprovalSummary>
    {
        public SingleApprovalQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
