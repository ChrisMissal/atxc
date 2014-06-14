namespace UI.Authorization
{
    using System;
    using System.Web.Mvc;
    using Microsoft.Practices.ServiceLocation;
    using NHibernate;

    public class TenantFilterAttribute : IAuthorizationFilter
    {
        private readonly Guid _tenantId;

        public TenantFilterAttribute()
        {
            dynamic config = new Formo.Configuration();

            _tenantId = Guid.Parse(config.TenantId);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = ServiceLocator.Current.GetInstance<ISession>();
            session.EnableFilter("tenant").SetParameter("TenantId", _tenantId);
        }
    }
}