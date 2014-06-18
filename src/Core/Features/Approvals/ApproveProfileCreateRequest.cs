namespace Core.Features.Approvals
{
    using Entities;
    using MediatR;

    public class ApproveProfileCreateRequest : IAsyncRequest<PersonSummary>
    {
        public ApproveProfileCreateRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}