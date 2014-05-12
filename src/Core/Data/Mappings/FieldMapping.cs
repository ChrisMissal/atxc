namespace Core.Data.Mappings
{
    using NHibernate.Mapping.ByCode.Conformist;

    public abstract class FieldMapping<T> : ClassMapping<T> where T : class, IField
    {
        protected FieldMapping()
        {
            Table(typeof(T).Name);
            ComposedId(m =>
            {
                m.Property(x => x.PersonId);
                m.Property(x => x.Value);
            });
            Property(x => x.PersonId);
            Property(x => x.Value);

            Property(x => x.Created, m =>
            {
                m.NotNullable(true);
                m.Column(cm =>
                {
                    cm.Default("getdate()");
                    cm.SqlType("datetime2");
                });
            });
            Property(x => x.Deleted, m => m.Column(cm => cm.SqlType("datetime2")));
        }
    }
}