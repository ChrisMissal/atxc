namespace UI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Core.Entities;
    using Core.Features.Approvals;
    using MediatR;

    public class ApprovalController : BaseController
    {
        private readonly IMediator _mediator;

        public ApprovalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ApprovalSummary> Get(string id)
        {
            var request = new SingleApprovalQuery { Id = id };
            var approval = await _mediator.SendAsync(request);

            approval.Person.ImageUrl = approval.Person.GetImageUrl();

            return approval;
        }

        public async Task<PersonSummary> Post(string id)
        {
            var request = new ApproveProfileCreateRequest { Id = id };
            return await _mediator.SendAsync(request);
        }

        public void Delete(string id)
        {
            var request = new DenyProfileCreateRequest { Id = id };
            _mediator.Send(request);
        }
    }
}