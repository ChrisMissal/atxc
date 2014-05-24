namespace UI.Mappings
{
    using AutoMapper;
    using Core;
    using Core.Entities;
    using Core.Enumeration;

    public class EnumerationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Category, CategoryField>()
                .ConvertUsing<EnumerationToFieldResolver<Category, CategoryField>>();
            CreateMap<Link, LinkField>()
                .ConvertUsing<EnumerationToFieldResolver<Link, LinkField>>();
        }
    }

    public class EnumerationToFieldResolver<TEnum, TField> : TypeConverter<TEnum, TField>
        where TField : IField, new()
        where TEnum : SlugEnumeration<TEnum>
    {
        protected override TField ConvertCore(TEnum source)
        {
            return new TField
            {
                Value = source.Value,
            };
        }
    }
}