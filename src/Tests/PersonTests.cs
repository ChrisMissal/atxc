using Core;
using Core.Enumeration;
using Shouldly;

namespace Tests
{
    public class PersonTests
    {
        public void Creative_should_produce_correct_link()
        {
            var creative = new Person {Name = "John Doe", Bio = "i'm neat", Location = Location.Austin};

            creative.Url.ShouldBe("#/profile/john-doe");
        }
    }
}