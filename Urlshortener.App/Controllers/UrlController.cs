using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    public class UrlController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Shorten(string url)
        {
            string shortUrl;

            bool urlAlreadyProcessed = UrlRepository.IsOriginalUrlInDatabase(url);
            if (urlAlreadyProcessed) shortUrl = UrlRepository.GetShortenedUrl(url);
            else shortUrl = ShortUrlService.ShortenUrl(url);

            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            return RedirectToAction("Result", new { shortenedUrl = $"{baseUrl}/{shortUrl}"});
        }

        public IActionResult Result(string shortenedUrl)
        {
            ViewData["ShortenedUrl"] = shortenedUrl;
            return View();
        }

        public IActionResult CustomRedirect(string shortUrl)
        {
            if (UrlRepository.IsShortenedUrlInDatabase(shortUrl))
            {
                return Redirect(UrlRepository.GetOriginalUrl(shortUrl));
            }
            else return View("~/Views/Shared/NotFound.cshtml");
        }
    }
}