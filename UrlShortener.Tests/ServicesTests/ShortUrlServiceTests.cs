using UrlShortener.Services;

namespace UrlShortener.Tests.ServicesTests
{
    public class ShortUrlServiceTests
    {
        public static IEnumerable<object[]> TestUrls => new List<object[]>
        {
            new object[] { "https://www.youtube.com/watch?v=7PIji8OubXU" },
            new object[] { "https://www.codewars.com/kata/5865918c6b569962950002a1/train/csharp" },
            new object[] { "https://en.wikipedia.org/wiki/Wikipedia:Wikipedia_Signpost/2023-07-03/News_and_notes" },
            new object[] { "https://www.webofscience.com/wos/author/record/2305295" },
            new object[] { "https://docs.codewars.com/languages/bf/codewars-test" },
            new object[] { "https://leconjugueur.lefigaro.fr/conjugaison/verbe/choisir.html" },
            new object[] { "https://www.deepl.com/translator#uk/en/%D0%A2%D0%B5%D1%81%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F%20URL" },
            new object[] { "https://translate.google.com/?hl=uk&sl=uk&tl=en&text=%D0%A2%D0%B5%D1%81%D1%82%D1%83%D0%B2%D0%B0%D0%BD%D0%BD%D1%8F%20Url%20&op=translate" },
            new object[] { "https://www.nintendo.com/store/products/super-mario-bros-wonder-switch/" },
            new object[] { "https://www.afternic.com/forsale/theworldsworstwebsiteever.com?traffic_id=GoDaddy_DLS&traffic_type=TDFS" }
        };

        [Theory]
        [MemberData(nameof(TestUrls))]
        public void GenerateShortUrl_DoesNotContainProhibitedCharacters(string url)
        {
            char[] unsuitableChars = {
                '/', '?', '#', '&', '=', '+', '%',
                '\0', '\a', '\b', '\f', '\n', '\r', '\t', '\v',
                ' ', '\t', '\r', '\n'
            };

            string shortenUrl = ShortUrlService.GenerateShortUrl(url);

            Assert.DoesNotContain(shortenUrl, c => unsuitableChars.Contains(c));
        }

        [Theory]
        [MemberData(nameof(TestUrls))]
        public void GenerateShortUrl_LengthEqualsEightCharacters(string url)
        {
            string shortenUrl = ShortUrlService.GenerateShortUrl(url);

            Assert.Equal(8, shortenUrl.Length);
        }

        [Theory]
        [MemberData(nameof(TestUrls))]
        public void GenerateShortUrl_ContainsOnlyAllowedCharacters(string url)
        {
            string pattern = @"^[a-zA-Z0-9-_]+$";

            string shortenUrl = ShortUrlService.GenerateShortUrl(url);

            Assert.Matches(pattern, shortenUrl);
        }
    }
}
