namespace Core.Entities
{
    using System;

    public class Approval : IEntity
    {
        public Approval()
        {
            Slug = Guid.NewGuid().ToString("n");
        }

        public virtual int Id { get; set; }
        public virtual string Slug { get; protected set; }
        public virtual Person Person { get; set; }
        public virtual Guid TenantId { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}
