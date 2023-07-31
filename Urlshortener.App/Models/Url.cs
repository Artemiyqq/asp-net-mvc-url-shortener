namespace UrlShortener.Models
{
    public class Url
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortenedUrl { get; set; }
    }
}