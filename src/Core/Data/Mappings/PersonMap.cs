namespace Core.Data.Mappings
{
    using Entities;
    using Enumeration;

    public class PersonMap : Mapping<Person>
    {
        public PersonMap()
        {
            Property(x => x.Approved);
            Property(x => x.Bio);
            Property(x => x.Email);
            Property(x => x.Joined);
            Property(x => x.Location, m => m.Type<EnumerationType<Location>>());
            Property(x => x.Name);
            Property(x => x.Slug);
        }
    }
}
