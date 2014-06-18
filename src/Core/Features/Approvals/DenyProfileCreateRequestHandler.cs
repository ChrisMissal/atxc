namespace Core.Features.Approvals
{
    using System.Linq;
    using Entities;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;

    public class DenyProfileCreateRequestHandler : IRequestHandler<DenyProfileCreateRequest, Unit>
    {
        private readonly ISession _session;

        public DenyProfileCreateRequestHandler(ISession session)
        {
            _session = session;
        }

        public Unit Handle(DenyProfileCreateRequest message)
        {
            var approval = _session.Query<Approval>().SingleOrDefault(x => x.Slug == message.Id);

            if (approval != null)
            {
                var now = SystemClock.UtcNow;
                var person = approval.Person;

                person.Deleted = now;
                _session.SaveOrUpdate(person);

                approval.Deleted = now;
                _session.SaveOrUpdate(approval);
            }

            return new Unit();
        }
    }
}