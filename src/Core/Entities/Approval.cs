namespace Core.Entities
{
    using System;

    public class Approval
    {
        public virtual Guid Id { get; set; }
        public virtual Person Person { get; set; }
    }
}
