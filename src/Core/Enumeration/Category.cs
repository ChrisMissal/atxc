namespace Core.Enumeration
{
    public class Category : SlugEnumeration<Category>
    {
        public static readonly Category Developer = new Category("Developer");
        public static readonly Category Designer = new Category("Designer");
        public static readonly Category Writer = new Category("Writer");
        public static readonly Category Photographer = new Category("Photographer");
        public static readonly Category Musician = new Category("Musician");

        private Category(string displayName) : base(displayName)
        {
        }
    }
}