namespace Core.Data.Mappings
{
    using Entities;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    public class ApprovalMapping : ClassMapping<Approval>
    {
        public ApprovalMapping()
        {
            Id(x => x.Id, m => m.Generator(new GuidGeneratorDef()));
            ManyToOne(p => p.Person, m =>
            {
                m.Column(PersonMapping.GetIdColumnName());
                m.NotNullable(true);
                m.Class(typeof(Person));
            });
        }
    }
}