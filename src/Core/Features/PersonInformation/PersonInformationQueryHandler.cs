namespace Core.Features.PersonInformation
{
    using System.Threading.Tasks;
    using Enumeration;
    using MediatR;
    using NHibernate;

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
                const string sql = @"select count(0) [PeopleCount] from Person";
                var peopleCount = _session.CreateSQLQuery(sql).UniqueResult<int>();

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