namespace Core.Features.People
{
    using Entities;
    using MediatR;

    public class SinglePersonQuery : IAsyncRequest<PersonSummary>
    {
        public string Id { get; set; }
    }
}