namespace Core.Features.Approvals
{
    using System;
    using Entities;
    using MediatR;

    public class SingleApprovalQuery : IAsyncRequest<ApprovalSummary>
    {
        public SingleApprovalQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
