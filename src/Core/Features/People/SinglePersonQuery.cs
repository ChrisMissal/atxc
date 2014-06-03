namespace Core.Features.People
{
    using Entities;
    using MediatR;

    public class SinglePersonQuery : IAsyncRequest<PersonSummary>
    {
        public SinglePersonQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}