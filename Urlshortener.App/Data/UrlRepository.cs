using UrlShortener.Models;

namespace UrlShortener.Data
{
    public static class UrlRepository
    {
        public static bool IsOriginalUrlInDatabase(string url, string schema = "public")
        {
            using var context = new AppDbContext(schema);

            return context.Urls.FirstOrDefault(u => u.OriginalUrl == url) != null;
        }

        public static bool IsShortenedUrlInDatabase(string url, string schema = "public")
        {
            using var context = new AppDbContext(schema);

            return context.Urls.FirstOrDefault(u => u.ShortenedUrl == url) != null;
        }

        public static string GetOriginalUrl(string shortenedUrl, string schema = "public")
        {
            using var context = new AppDbContext(schema);
            var url = context.Urls.FirstOrDefault(u => u.ShortenedUrl == shortenedUrl);

            return url!.OriginalUrl;
        }

        public static string GetShortenedUrl(string originalUrl, string schema = "public")
        {
            using var context = new AppDbContext(schema);
            var url = context.Urls.FirstOrDefault(u => u.OriginalUrl == originalUrl);

            return url!.ShortenedUrl;
        }

        public static void SaveNewUrl(string originalUrl, string shortenedUrl, string schema = "public")
        {
            using var context = new AppDbContext(schema);
            var newUrl = new Url
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortenedUrl
            };

            context.Urls.Add(newUrl);
            context.SaveChanges();
        }
    }
}
