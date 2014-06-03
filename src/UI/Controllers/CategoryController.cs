namespace UI.Controllers
{
    using System.Threading.Tasks;
    using Core;
    using Core.Entities;
    using Core.Enumeration;
    using Core.Features.People;
    using MediatR;

    public class CategoryController : EnumerationController<Category>
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PeopleCollection<Category>> Get(string id)
        {
            var category = Category.FromValue(id);
            var query = new PeopleByCategoryQuery { Category = category };
            var collection = await _mediator.SendAsync(query);

            collection.People.ForEach(p => { p.ImageUrl = p.GetImageUrl(); });

            return collection;
        }
    }
}