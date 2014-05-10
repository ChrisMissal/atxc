namespace UI.Controllers
{
    using System.Collections.Generic;
    using Core.Entities;
    using Core.Enumeration;

    public class CategoryController : EnumerationController<Category>
    {
        public PeopleCollection<Category> Get(string id)
        {
            var type = Category.FromValue(id);
            var result = new PeopleCollection<Category>(type)
            {
                People = new List<Person>
                {
                    new Person {Name = "Chris Missal", Location = Location.Austin},
                    new Person {Name = "Darby McGillicutty", Location = Location.Austin},
                }
            };
            return result;
        }
    }
}