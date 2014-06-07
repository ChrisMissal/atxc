namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;
    using NHibernate;

    public class PersonCreatedNotificationHandler : IAsyncNotificationHandler<PersonCreatedNotification>
    {
        private readonly ISession _session;

        public PersonCreatedNotificationHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(PersonCreatedNotification notification)
        {
            var approval = new Approval
            {
                Person = _session.Load<Person>(notification.Id),
            };
            _session.SaveOrUpdate(approval);
            return null;
        }
    }
}