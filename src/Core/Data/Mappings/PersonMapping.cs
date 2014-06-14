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
            Property(x => x.Random, m => m.Formula("NEWID()"));

            Bag(x => x.Categories, c =>
            {
                c.Cascade(Cascade.All);
                c.Inverse(true);
                c.Key(k => k.Column(GetIdColumnName()));

            }, r =>
            {
                r.OneToMany(m =>
                {
                    m.NotFound(NotFoundMode.Exception);
                    m.Class(typeof (CategoryField));
                });
            });

            Bag(x => x.Links, l =>
            {
                l.Cascade(Cascade.All);
                l.Inverse(true);
                l.Key(k => k.Column(GetIdColumnName()));
            }, r =>
            {
                r.OneToMany(m =>
                {
                    m.NotFound(NotFoundMode.Exception);
                    m.Class(typeof (LinkField));
                });
            });
        }
    }
}
