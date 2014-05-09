namespace UI
{
    using Core.Entities;
    using GravatarHelper;

    public static class Extensions
    {
        public static string GetImageUrl(this Person self)
        {
            return GravatarHelper.CreateGravatarUrl(self.Email, 200, defaultImage: null, rating: GravatarRating.PG, addExtension: true, forceDefault: false);
        }
    }
}