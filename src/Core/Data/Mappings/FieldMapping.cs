namespace Core.Data.Mappings
{
    using Entities;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    public abstract class FieldMapping<T> : ClassMapping<T> where T : class, IField
    {
        protected FieldMapping()
        {
            Table(GetTableName());

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.HighLow);
                m.Column(typeof(T).GetIdColumnName());
            });
            ManyToOne(x => x.Person, m =>
            {
                m.Column(typeof(Person).GetIdColumnName());
                m.NotNullable(true);
                m.Class(typeof(Person));
                m.UniqueKey("PersonValue");
            });
                
            Property(x => x.TenantId, m => m.NotNullable(true));
            Property(x => x.Value, m => m.UniqueKey("PersonValue"));
            Property(x => x.Created, m => m.Column(cm =>
            {
                cm.SqlType("datetime2");
                cm.NotNullable(true);
            }));
            Filter("tenant", fm => { });
        }

        public static string GetTableName()
        {
            return typeof (T).Name;
        }
    }
}