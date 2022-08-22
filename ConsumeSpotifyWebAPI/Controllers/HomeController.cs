using ConsumeSpotifyWebAPI.Models;
using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumeSpotifyWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;

        public HomeController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";
            try
            {
                token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
            }
            catch (Exception ex)
            {

                Debug.Write(ex);
            }
            ViewBag.token = token;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}