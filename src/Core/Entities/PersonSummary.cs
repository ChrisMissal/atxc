namespace Core.Entities
{
    public class PersonSummary : IHaveEmail, ILinkable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }

        public virtual string Url
        {
            get { return string.Format("#/profile/{0}", Slug); }
        }
    }
}