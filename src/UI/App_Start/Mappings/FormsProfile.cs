namespace UI.Mappings
{
    using Core.Features.People;
    using Models;

    public class FormsProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<PersonForm, CreatePersonRequest>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}