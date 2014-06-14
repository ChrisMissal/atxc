namespace DataLoader
{
    using System;
    using Core.Data;

    internal class LoaderDatabaseSettings : DatabaseSettings
    {
        private readonly Guid _tenantId;

        public LoaderDatabaseSettings(Guid tenantId)
        {
            _tenantId = tenantId;
        }

        public override Guid TenantId
        {
            get { return _tenantId; }
        }
    }
}