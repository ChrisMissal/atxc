namespace UI
{
    using System.Web.Mvc;
    using Authorization;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TenantFilterAttribute());
        }
    }
}