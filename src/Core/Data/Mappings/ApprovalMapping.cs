namespace Core.Data.Mappings
{
    using Entities;

    public class ApprovalMapping : Mapping<Approval>
    {
        public ApprovalMapping()
        {
            Property(x => x.Slug, m => m.NotNullable(true));
            Property(x => x.TenantId, m => m.NotNullable(true));
            Property(x => x.Deleted, m => m.Column(cm => cm.SqlType("datetime2")));
            ManyToOne(p => p.Person, m =>
            {
                m.Column(PersonMapping.GetIdColumnName());
                m.NotNullable(true);
                m.Class(typeof(Person));
            });
        }
    }
}