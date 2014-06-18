namespace Core.Features.Approvals
{
    using Entities;
    using MediatR;

    public class SingleApprovalQuery : IAsyncRequest<ApprovalSummary>
    {
        public string Id { get; set; }
    }
}
