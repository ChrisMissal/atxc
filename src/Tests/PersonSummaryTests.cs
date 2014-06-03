namespace Tests
{
    using Core.Entities;
    using Shouldly;

    public class PersonSummaryTests
    {
        public void Person_should_produce_correct_link()
        {
            var person = new PersonSummary { Slug = "john-doe" };

            person.Url.ShouldBe("#/profile/john-doe");
        }
    }
}