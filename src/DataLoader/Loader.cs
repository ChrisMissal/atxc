namespace DataLoader
{
    using NHibernate;
    using NHibernate.Linq;
    using Ploeh.AutoFixture;

    internal abstract class Loader<T> : ILoader
    {
        protected readonly LoaderConfig _config;
        protected readonly Fixture _fixture;
        protected readonly ISession _session;

        protected Loader(LoaderConfig config, Fixture fixture, ISession session)
        {
            _config = config;
            _fixture = fixture;
            _session = session;
        }

        protected abstract object Create();

        public void Load(int count)
        {
            if (_config.Delete)
            {
                foreach (var entity in _session.Query<T>())
                    _session.Delete(entity);
            }

            if (_config.NoLoad)
                return;

            for (var i = 0; i < count; i++)
            {
                var entity = Create();
                _session.SaveOrUpdate(entity);
            }
        }
    }
}