namespace Core.Features.People
{
    using Entities;
    using MediatR;

    public class RandomPersonQuery : IAsyncRequest<PersonSummary>
    {
    }
}