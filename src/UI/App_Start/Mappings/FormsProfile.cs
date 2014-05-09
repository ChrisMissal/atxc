namespace UI.Mappings
{
    using AutoMapper;
    using Core.Enumeration;
    using Core.Features.People;
    using Models;

    public class FormsProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PersonForm, CreatePersonRequest>()
                .ForMember(x => x.Location, m => m.ResolveUsing<EnumerationResolver<Location>>().FromMember(s => s.Location))
                .ForMember(x => x.Categories, m => m.ResolveUsing<EnumerationListResolver<Category>>().FromMember(s => s.Categories))
                .ForMember(x => x.Links, m => m.ResolveUsing<EnumerationListResolver<Link>>().FromMember(s => s.Links))
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}