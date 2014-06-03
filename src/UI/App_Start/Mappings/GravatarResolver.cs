namespace UI.Mappings
{
    using AutoMapper;
    using Core.Entities;

    public class GravatarResolver : ValueResolver<Person, string>
    {
        protected override string ResolveCore(Person source)
        {
            return source.GetImageUrl();
        }
    }
}