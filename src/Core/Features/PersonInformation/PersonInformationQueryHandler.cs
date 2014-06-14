namespace Core.Features.PersonInformation
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Enumeration;
    using MediatR;
    using NHibernate;
    using NHibernate.Linq;

    public class PersonInformationQueryHandler : IAsyncRequestHandler<PersonInformationQuery, Information>
    {
        private readonly ISession _session;

        public PersonInformationQueryHandler(ISession session)
        {
            _session = session;
        }

        public Task<Information> Handle(PersonInformationQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var peopleCount = _session.Query<Person>().Count();

                return new Information
                {
                    NumberOfPeople = peopleCount,
                    NumberOfCategories = Category.GetAll().Length,
                    NumberOfLocations = Location.GetAll().Length,
                };
            });
        }
    }
}