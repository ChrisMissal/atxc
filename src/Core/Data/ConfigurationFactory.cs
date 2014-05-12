namespace Core.Data
{
    using System.Configuration;
    using System.Reflection;
    using Entities;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;
    using Configuration = NHibernate.Cfg.Configuration;

    public class ConfigurationFactory
    {
        private readonly Configuration _configuration;
        private readonly ISessionFactory _sessionFactoryBuilder;

        public ConfigurationFactory()
        {
            dynamic config = new Formo.Configuration();
            ConnectionStringSettings connection = config.ConnectionString.Atxc;

            _configuration = new Configuration()
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString = connection.ConnectionString;
                    db.Dialect<MsSql2012Dialect>();
                    db.BatchSize = 100;
                });

            var mapping = GetMappings();
            _configuration.AddDeserializedMapping(mapping, "schema");
            SchemaMetadataUpdater.QuoteTableAndColumns(_configuration);
            new SchemaExport(_configuration).SetOutputFile(@"c:\temp\atxc_schema.ddl").Execute(true, true, false);
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
    }

}
