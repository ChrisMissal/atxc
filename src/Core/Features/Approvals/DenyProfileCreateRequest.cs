namespace Core.Features.Approvals
{
    using MediatR;

    public class DenyProfileCreateRequest : IRequest<Unit>
    {
        public string Id { get; set; }
    }
}