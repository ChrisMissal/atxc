namespace UI.Controllers
{
    using System.Threading.Tasks;
    using Core.Features.PersonInformation;
    using MediatR;

    public class InformationController : BaseController
    {
        private readonly IMediator _mediator;

        public InformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Information> Get()
        {
            return await _mediator.SendAsync(new PersonInformationQuery());
        }
    }
}