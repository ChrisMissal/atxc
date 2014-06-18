namespace Core.Features.Approvals
{
    using MediatR;

    public class DenyProfileCreateRequest : IRequest<Unit>
    {
        public DenyProfileCreateRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}