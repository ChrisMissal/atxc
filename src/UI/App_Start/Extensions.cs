using Core;
using GravatarHelper;

namespace UI
{
    public static class Extensions
    {
        public static string GetImageUrl(this Person self)
        {
            return GravatarHelper.GravatarHelper.CreateGravatarUrl(self.Email, 200, defaultImage: null, rating: GravatarRating.PG, addExtension: true, forceDefault: false);
        }
    }
}