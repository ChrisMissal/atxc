namespace UI
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Mappings;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            var container = Bootstrapper.BootstrapApplication(config);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(config);
            FormattingConfig.Register(config);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MappingConfig.Register(container);
            ValidationConfig.Register(container);

            Bootstrapper.ValidateApplication();
        }
    }
}