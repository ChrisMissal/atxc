namespace IntegrationTests
{
    using System;
    using Core.Data;

    public class IntegrationTestDatabaseSettings : DatabaseSettings
    {
        private readonly Guid _tenantId;

        public IntegrationTestDatabaseSettings()
        {
            _tenantId = Guid.NewGuid();
        }

        public override string ConnectionString
        {
            get { return Default.ConnectionString; }
        }

        public override Guid TenantId
        {
            get { return _tenantId; }
        }
    }
}