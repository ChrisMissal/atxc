namespace Tests
{
    using Core.Entities;
    using Core.Enumeration;
    using Shouldly;

    public class PersonTests
    {
        public void Person_should_produce_correct_link()
        {
            var person = new Person { Name = "John Doe", Bio = "i'm neat", Location = Location.Austin };

            person.Url.ShouldBe("#/profile/john-doe");
        }
    }
}