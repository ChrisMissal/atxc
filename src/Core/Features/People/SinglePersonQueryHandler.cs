namespace Core.Features.People
{
    using System.Threading.Tasks;
    using Entities;
    using MediatR;

    public class SinglePersonQueryHandler : IAsyncRequestHandler<SinglePersonQuery, Person>
    {
        public Task<Person> Handle(SinglePersonQuery message)
        {
            return Task.Factory.StartNew(() => new Person());
        }
    }
}