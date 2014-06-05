namespace DataLoader.Generators
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Ploeh.AutoFixture.Kernel;

    internal class NameGenerator : ISpecimenBuilder
    {
        private readonly Random _random = new Random();
        private readonly PersonInfoGatherer _gatherer;
        private readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

        public NameGenerator(PersonInfoGatherer gatherer)
        {
            _gatherer = gatherer;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null || !pi.Name.Contains("Name"))
                return new NoSpecimen(request);

            var firstNames = _gatherer.FirstNames.ToArray();
            var lastNames = _gatherer.LastNames.ToArray();

            var first = firstNames.ElementAt(_random.Next(firstNames.Count()));
            var last = lastNames.ElementAt(_random.Next(lastNames.Count()));

            return string.Format("{0} {1}", _textInfo.ToTitleCase(first), _textInfo.ToTitleCase(last));
        }
    }
}