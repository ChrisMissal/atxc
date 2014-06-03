namespace UI
{
    using Core;
    using GravatarHelper;

    public static class Extensions
    {
        public static string GetImageUrl(this IHaveEmail self)
        {
            return GravatarHelper.CreateGravatarUrl(self.Email, 200, defaultImage: null, rating: GravatarRating.PG, addExtension: true, forceDefault: false);
        }
    }
}