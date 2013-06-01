using Core.Enumeration;
using Shouldly;

namespace Tests
{
    public class CategoryTests
    {
        public void Category_should_produce_correct_link()
        {
            Category.Developer.Url.ShouldBe("/category/developer");
        }
    }
}