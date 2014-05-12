namespace Core.Enumeration
{
    public abstract class SlugEnumeration<T> : Enumeration<T, string>, ISlugEnumeration, ILinkable where T : Enumeration<T, string>
    {
        protected SlugEnumeration(string displayName) : base(displayName.ToSlug(), displayName)
        {
            var type = GetType().Name.ToLower();
            var slug = DisplayName.ToSlug();

            Url = string.Format("#/{0}/{1}", type, slug);
        }

        public virtual string Url { get; private set; }
    }
}