namespace Core.Enumeration
{
    public class Link : SlugEnumeration<Link>
    {
        public static readonly Link Twitter = new Link("http://twitter.com/{0}", "Twitter");
        public static readonly Link Facebook = new Link("http://www.facebook.com/{0}", "Facebook");
        public static readonly Link LinkedIn = new Link("http://www.linkedin.com/in/{0}", "LinkedIn");

        public Link(string urlFormat, string displayName) : base(displayName)
        {
            UrlFormat = urlFormat;
        }

        public string UrlFormat { get; set; }
    }
}