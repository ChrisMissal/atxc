namespace Core.Features.People
{
    using System.Collections.Generic;
    using Entities;
    using MediatR;

    public class PersonQuery : IAsyncRequest<List<PersonSummary>>
    {
    }
}