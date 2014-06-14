namespace Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Entities;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Engine;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;
    using NHibernate.Type;
    using Configuration = NHibernate.Cfg.Configuration;

    public class ConfigurationFactory
    {
        private readonly Configuration _configuration;
        private readonly ISessionFactory _sessionFactoryBuilder;

        public ConfigurationFactory(DatabaseSettings settings)
        {
            _configuration = new Configuration()
                .SetInterceptor(new TenantIdInterceptor(settings.TenantId))
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString = settings.ConnectionString;
                    db.Dialect<MsSql2012Dialect>();
                    db.BatchSize = 100;
                });

            _configuration
                .AddFilterDefinition(new TenantIdDefinition(settings.TenantId));

            var mapping = GetMappings();
            _configuration.AddDeserializedMapping(mapping, "schema");
            SchemaMetadataUpdater.QuoteTableAndColumns(_configuration);
            new SchemaExport(_configuration).SetOutputFile(@"c:\temp\atxc_schema.ddl").Execute(false, false, false);
            _sessionFactoryBuilder = _configuration.BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory()
        {
            return _sessionFactoryBuilder;
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        private static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetAssembly(typeof(Person)).GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        private class TenantIdDefinition : FilterDefinition
        {
            public TenantIdDefinition(dynamic tenantId) : base("tenant", "TenantId = :TenantId", new Dictionary<string, IType> { {"TenantId", new GuidType() } }, true)
            {
            }
        }

        private class TenantIdInterceptor : EmptyInterceptor
        {
            private readonly Guid _tenantId;

            public TenantIdInterceptor(Guid tenantId)
            {
                _tenantId = tenantId;
            }

            public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
            {
                var baseEntity = entity as ITenanted;
                if (baseEntity == null)
                    return false;

                var index = Array.IndexOf(propertyNames, "TenantId");

                state[index] = _tenantId;
                baseEntity.TenantId = _tenantId;

                return true;
            }

            public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
            {
                var baseEntity = entity as ITenanted;

                if (baseEntity != null && baseEntity.TenantId == Guid.Empty)
                {
                    var index = Array.IndexOf(propertyNames, "TenantId");

                    currentState[index] = _tenantId;
                    baseEntity.TenantId = _tenantId;
                }

                return true;
            }

            public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types)
            {
                if (!(entity is ITenanted))
                    return true;

                var index = Array.IndexOf(propertyNames, "TenantId");
                var tenantId = (Guid) state[index];

                if (tenantId == null)
                    return true;

                if (tenantId != _tenantId)
                    throw new UnauthorizedAccessException();

                return true;
            }
        }
    }
}
