namespace Core.Features.Approvals
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;

    public class ApproveProfileCreateRequestHandler : IAsyncRequestHandler<ApproveProfileCreateRequest, PersonSummary>
    {
        private readonly ISession _session;

        public ApproveProfileCreateRequestHandler(ISession session)
        {
            _session = session;
        }

        public Task<PersonSummary> Handle(ApproveProfileCreateRequest message)
        {
            return Task.Factory.StartNew(() =>
            {
                var approval = _session.Query<Approval>().SingleOrDefault(x => x.Slug == message.Id);

                if (approval == null)
                    return default(PersonSummary);

                var person = approval.Person;
                if (person == null)
                    return default(PersonSummary);

                var now = SystemClock.UtcNow;

                person.Approved = now;
                _session.SaveOrUpdate(person);

                approval.Deleted = now;
                _session.SaveOrUpdate(approval);

                return new PersonSummary
                {
                    Slug = person.Slug,
                };
            });
        }
    }
}