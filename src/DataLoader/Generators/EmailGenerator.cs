namespace DataLoader.Generators
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Ploeh.AutoFixture.Kernel;

    internal class EmailGenerator : ISpecimenBuilder
    {
        private readonly Random _random = new Random();
        private static readonly string[] _domains = { "gmail.com", "yahoo.com", "aol.com", "msn.com" };
        private static readonly string[] _dividers = { "", ".", "-", "_" };
        private readonly PersonInfoGatherer _gatherer;

        public EmailGenerator(PersonInfoGatherer gatherer)
        {
            _gatherer = gatherer;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null || !pi.Name.Contains("Email"))
                return new NoSpecimen(request);

            var firstNames = _gatherer.FirstNames.ToArray();
            var lastNames = _gatherer.LastNames.ToArray();

            var first = firstNames.ElementAt(_random.Next(firstNames.Count()));
            var last = lastNames.ElementAt(_random.Next(lastNames.Count()));
            var domain = _domains.ElementAt(_random.Next(_domains.Length));
            var divider = _dividers.ElementAt(_random.Next(_dividers.Length));

            return string.Format("{0}{1}{2}@{3}", first, divider, last, domain);
        }
    }
}