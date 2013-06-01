using System;

namespace Core
{
    public static class Site
    {
        static Site()
        {
            dynamic config = new Formo.Configuration();
            SiteUrl = config.SiteUrl<Uri>("/");
        }

        public static Uri SiteUrl { get; private set; }
    }
}