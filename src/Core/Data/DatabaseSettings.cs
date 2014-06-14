namespace Core.Data
{
    using System;
    using System.Configuration;

    public class DatabaseSettings
    {
        public static readonly DatabaseSettings Default = new Lazy<DatabaseSettings>(GetDefaultSettings).Value;

        private static DatabaseSettings GetDefaultSettings()
        {
            dynamic config = new Formo.Configuration();
            ConnectionStringSettings connection = config.ConnectionString.Atxc;

            return new DatabaseSettings
            {
                ConnectionString = connection.ConnectionString,
                TenantId = Guid.Parse(config.TenantId),
            };
        }

        public virtual string ConnectionString { get; private set; }

        public virtual Guid TenantId { get; private set; }
    }
}