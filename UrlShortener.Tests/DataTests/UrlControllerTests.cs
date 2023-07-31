using UrlShortener.Data;

namespace UrlShortener.Tests.DataTests
{
    public class UrlControllerTests
    {
        [Fact]
        public void IsOriginalUrlInDatabase_ExistingUrl_ReturnTrue()
        {
            string originalUrl = "https://duckduckgo.com/about";
            string schema = "tests";

            bool result = UrlRepository.IsOriginalUrlInDatabase(originalUrl, schema);

            Assert.True(result);
        }

        [Fact]
        public void IsOriginalUrlInDatabase_NotExistingUrl_ReturnFalse()
        {
            string originalUrl = "https://www.example.com";
            string schema = "tests";

            bool result = UrlRepository.IsOriginalUrlInDatabase(originalUrl, schema);

            Assert.False(result);
        }

        [Fact]
        public void IsShortenedUrlInDatabase_ExistingUrl_ReturnTrue()
        {
            string shortenedlUrl = "_K-3Xjd_";
            string schema = "tests";

            bool result = UrlRepository.IsShortenedUrlInDatabase(shortenedlUrl, schema);

            Assert.True(result);
        }

        [Fact]
        public void IsShortenedUrlInDatabase_NotExistingUrl_ReturnFalse()
        {
            string shortenedlUrl = "A123bcde";
            string schema = "tests";

            bool result = UrlRepository.IsShortenedUrlInDatabase(shortenedlUrl, schema);

            Assert.False(result);
        }

        [Fact]
        public void GetOriginalUrl_ShortenedUrl_OriginalUrl()
        {
            string shortenedlUrl = "_K-3Xjd_";
            string originalUrl = "https://duckduckgo.com/about";
            string schema = "tests";

            string result = UrlRepository.GetOriginalUrl(shortenedlUrl, schema);

            Assert.Equal(result, originalUrl);
        }

        [Fact]
        public void GetShortenedUrl_OriginalUrl_ShortenedUrl()
        {
            string shortenedlUrl = "_K-3Xjd_";
            string originalUrl = "https://duckduckgo.com/about";
            string schema = "tests";

            string result = UrlRepository.GetShortenedUrl(originalUrl, schema);

            Assert.Equal(result, shortenedlUrl);
        }
    }
}
