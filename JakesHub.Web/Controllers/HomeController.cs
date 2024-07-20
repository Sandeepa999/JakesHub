using JakesHub.Web.Models;
using JakesHub.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JakesHub.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJokeRepository jokeRepository;

        public HomeController(ILogger<HomeController> logger, IJokeRepository jokeRepository)
        {
            _logger = logger;
            this.jokeRepository = jokeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var joke=await jokeRepository.GetAllAsync();
            return View(joke);
        }

        [HttpPost]
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase)
        {
            var joke=await jokeRepository.GetAllAsync(SearchPhrase);
            return View("Index", joke);
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
