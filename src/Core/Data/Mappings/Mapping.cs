namespace Core.Data.Mappings
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    public abstract class Mapping<T> : ClassMapping<T> where T : class, IEntity
    {
        protected Mapping()
        {
            Id(x => x.Id, m =>
            {
                m.Generator(Generators.HighLow);
                m.Column(GetIdColumnName());
            });
            Property(x => x.TenantId, m => m.NotNullable(true));
            Filter("tenant", fm => { });
        }

        protected string GetIdColumnName()
        {
            return typeof (T).GetIdColumnName();
        }
    }
}