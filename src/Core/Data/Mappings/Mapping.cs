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
        }

        public static string GetIdColumnName()
        {
            return typeof (T).Name + "Id";
        }
    }
}