namespace Core
{
    using System;

    public interface ITenanted
    {
        Guid TenantId { get; set; }
    }
}