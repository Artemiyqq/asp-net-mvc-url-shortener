using System.Security.Cryptography;
using System.Text;
using UrlShortener.Data;

namespace UrlShortener.Services
{
    public static class ShortUrlService
    {
        public static string ShortenUrl(string originalUrl)
        {
            string shortUrl = GenerateShortUrl(originalUrl);
            UrlRepository.SaveNewUrl(originalUrl, shortUrl);
            return shortUrl;
        }

        public static string GenerateShortUrl(string originalUrl)
        {
            byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(originalUrl));
            string base64Id = Convert.ToBase64String(hash).Replace("/", "_").Replace("+", "-")[..8];
            if (UrlRepository.IsShortenedUrlInDatabase(base64Id))
            {
                char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
                Random random = new();
                do
                {
                    int index = random.Next(characters.Length);
                    char randomChar = characters[index];

                    char[] base64IdChars = base64Id.ToCharArray();
                    base64IdChars[random.Next(0, 8)] = randomChar;
                    base64Id = new string(base64IdChars);
                }
                while (UrlRepository.IsShortenedUrlInDatabase(base64Id));
            }
            return base64Id;
        }
    }
}