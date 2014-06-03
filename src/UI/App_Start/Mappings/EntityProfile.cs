namespace UI.Mappings
{
    using AutoMapper;
    using Core.Entities;

    public class EntityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonSummary>()
                .ForMember(x => x.ImageUrl, m => m.ResolveUsing<GravatarResolver>());
        }
    }
}