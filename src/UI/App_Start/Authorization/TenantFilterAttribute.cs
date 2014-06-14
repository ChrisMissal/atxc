namespace UI.Authorization
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Microsoft.Practices.ServiceLocation;
    using NHibernate;

    public class TenantFilterAttribute : ActionFilterAttribute
    {
        private readonly Guid _tenantId;

        public TenantFilterAttribute()
        {
            dynamic config = new Formo.Configuration();

            _tenantId = Guid.Parse(config.TenantId);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            SetTenant(_tenantId);
            base.OnActionExecuting(actionContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            SetTenant(_tenantId);
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public static void SetTenant(Guid tenantId)
        {
            var session = ServiceLocator.Current.GetInstance<ISession>();
            session.EnableFilter("tenant").SetParameter("TenantId", tenantId);
         }
    }
}