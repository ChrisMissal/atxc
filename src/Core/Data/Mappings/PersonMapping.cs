namespace Core.Data.Mappings
{
    using Entities;
    using Enumeration;
    using NHibernate.Mapping.ByCode;

    public class PersonMapping : Mapping<Person>
    {
        public PersonMapping()
        {
            Property(x => x.Bio, m =>
            {
                m.NotNullable(true);
                m.Length(Constants.PersonBioLengthMax);
            });
            Property(x => x.Email, m => m.NotNullable(true));
            Property(x => x.Location, m =>
            {
                m.Type<EnumerationType<Location>>();
                m.NotNullable(true);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);
                m.Length(Constants.PersonNameLengthMax);
            });
            Property(x => x.Slug, m => m.NotNullable(true));

            Property(x => x.Joined, m => m.Column(cm => cm.SqlType("datetime2")));
            Property(x => x.Approved, m => m.Column(cm => cm.SqlType("datetime2")));
            Property(x => x.Deleted, m => m.Column(cm => cm.SqlType("datetime2")));

            Property(x => x.Categories);
            /*Set(x => x.Categories, m =>
            {
                m.Type<CategoryField>();
                m.Fetch(CollectionFetchMode.Join);
                m.Filter("NonDeletedCategories", f => f.Condition("(Deleted is null)"));
            });*/
        }
    }
}
