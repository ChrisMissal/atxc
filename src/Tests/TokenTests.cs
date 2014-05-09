namespace Tests
{
    using Core;
    using Shouldly;

    public class TokenTests
    {
        public void Token_should_produce_correct_strings()
        {
            "ATX Creatives".ToSlug().ShouldBe("atx-creatives");
        }
    }
}
