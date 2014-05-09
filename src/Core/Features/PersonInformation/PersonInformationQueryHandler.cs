namespace Core.Features.PersonInformation
{
    using System.Threading.Tasks;
    using Enumeration;
    using MediatR;

    public class PersonInformationQueryHandler : IAsyncRequestHandler<PersonInformationQuery, Information>
    {
        public Task<Information> Handle(PersonInformationQuery message)
        {
            return Task.Factory.StartNew(() => 
                new Information
                {
                    NumberOfPeople = 0, //peopleCount, todo
                    NumberOfCategories = Category.GetAll().Length,
                    NumberOfLocations = Location.GetAll().Length,
                });
        }
    }
}