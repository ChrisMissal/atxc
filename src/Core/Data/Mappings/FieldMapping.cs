namespace Core.Data.Mappings
{
    using Entities;
    using NHibernate.Mapping.ByCode.Conformist;

    public abstract class FieldMapping<T> : ClassMapping<T> where T : class, IField
    {
        protected FieldMapping()
        {
            Table(GetTableName());

            ComposedId(x =>
            {
                x.Property(p => p.Value);
                x.ManyToOne(p => p.Person, m =>
                {
                    m.Column(PersonMapping.GetIdColumnName());
                    m.NotNullable(true);
                    m.Class(typeof(Person));
                    m.UniqueKey("PersonValue");
                });
                
            });
            Property(x => x.Value, m => m.UniqueKey("PersonValue"));
            Property(x => x.Created, m => m.Column(cm =>
            {
                cm.SqlType("datetime2");
                cm.NotNullable(true);
            }));
            Property(x => x.Deleted, m => m.Column(cm => cm.SqlType("datetime2")));
        }

        public static string GetTableName()
        {
            return typeof (T).Name;
        }
    }
}