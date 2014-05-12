namespace UI.Mappings
{
    using AutoMapper;
    using Core;
    using Core.Enumeration;

    public class EnumerationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ISlugEnumeration, IField>().ForMember(x => x.PersonId, m => m.Ignore());
        }
    }
}