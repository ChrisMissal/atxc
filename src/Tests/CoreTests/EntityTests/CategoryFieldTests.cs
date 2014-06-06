namespace Tests.CoreTests.EntityTests
{
    using Core.Entities;
    using Core.Enumeration;
    using Shouldly;

    public class FieldTests
    {
        private class TestField : Field<Category> { }

        private class TestPerson : Person
        {
            public TestPerson(int id)
            {
                Id = id;
            }
        }

        public void Fields_with_same_value_should_be_equal()
        {
            var value1 = Category.Developer;
            var value2 = Category.Developer;

            object field1 = new TestField { Value = value1.Value, Person = new Person() };
            object field2 = new TestField { Value = value2.Value };

            field1.Equals(field2).ShouldBe(true);
        }

        public void Fields_with_same_value_for_different_people_should_not_be_equal()
        {
            var value1 = Category.Designer;
            var value2 = Category.Designer;

            object field1 = new TestField { Value = value1.Value, Person = new TestPerson(1) };
            object field2 = new TestField { Value = value2.Value, Person = new TestPerson(2) };

            field1.Equals(field2).ShouldBe(false);
        }
    }
}