namespace DataLoader.Generators
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Core.Enumeration;
    using Ploeh.AutoFixture.Kernel;

    internal class EnumerationGenerator<T> : ISpecimenBuilder where T : Enumeration<T, string>
    {
        private readonly Random _random = new Random();
        private readonly T[] _enumerations = SlugEnumeration<T>.GetAll();

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null || pi.PropertyType != typeof(T))
                return new NoSpecimen(request);

            return _enumerations.ElementAt(_random.Next(_enumerations.Length));
        }
    }
}