namespace Core.Features.People
{
    using Entities;
    using MediatR;

    public class SinglePersonQuery : IAsyncRequest<Person>
    {
        public SinglePersonQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}