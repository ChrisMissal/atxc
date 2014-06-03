namespace Core.Features.People
{
    using Entities;
    using Enumeration;
    using MediatR;

    public class PeopleByCategoryQuery : IAsyncRequest<PeopleCollection<Category>>
    {
        public Category Category { get; set; }
    }
}