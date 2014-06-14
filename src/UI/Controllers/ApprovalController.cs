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
            var approval = await _mediator.SendAsync(new SingleApprovalQuery(id));

            return approval;
        }
    }
}