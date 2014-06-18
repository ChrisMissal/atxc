namespace Core.Features.Approvals
{
    using Entities;
    using MediatR;

    public class ApproveProfileCreateRequest : IAsyncRequest<PersonSummary>
    {
        public string Id { get; set; }
    }
}