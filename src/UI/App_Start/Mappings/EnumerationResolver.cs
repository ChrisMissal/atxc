namespace UI.Mappings
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Enumeration;

    public class EnumerationResolver<T> : ValueResolver<string, T> where T : Enumeration<T, string>
    {
        protected override T ResolveCore(string source)
        {
            return Enumeration<T, string>.FromValue(source);
        }
    }

    public class EnumerationListResolver<T> : ValueResolver<List<string>, List<T>> where T : Enumeration<T, string>
    {
        protected override List<T> ResolveCore(List<string> source)
        {
            return source.Select(Enumeration<T, string>.FromValue).ToList();
        }
    }
}