using JakesHub.Web.Data;
using JakesHub.Web.Models;
using JakesHub.Web.Models.ViewModel;
using JakesHub.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JakesHub.Web.Controllers
{

    [Authorize]
    public class JokesController : Controller
    {
        private readonly IJokeRepository jokeRepository;

        public JokesController(IJokeRepository jokeRepository)
        {
            this.jokeRepository = jokeRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJokeRequest addJokeRequest)
        {
            var joke = new Joke
            {
                JokeQuestion = addJokeRequest.JokeQuestion,
                JokeAnswer = addJokeRequest.JokeAnswer,
            };
            await jokeRepository.AddAsync(joke);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var jokes = await jokeRepository.GetAllAsync();
            return View(jokes);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var joke = await jokeRepository.GetAsync(id);
            if (joke != null)
            {
                var editJokeRequest = new EditJokeRequest
                {
                    Id = joke.Id,
                    JokeAnswer = joke.JokeAnswer,
                    JokeQuestion = joke.JokeQuestion

                };
                return View(editJokeRequest);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditJokeRequest editJokeRequest)
        {
            var joke = new Joke
            {
                JokeAnswer = editJokeRequest.JokeAnswer,
                JokeQuestion = editJokeRequest.JokeQuestion
            };
            var updatedJokes = await jokeRepository.UpdateAsync(joke);
            if (updatedJokes != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditJokeRequest editJokeRequest)
        {
            var deletedJoke = await jokeRepository.DeleteAsync(editJokeRequest.Id);
            if (deletedJoke != null)
            {
                return RedirectToAction("List");
            }


            return RedirectToAction("Edit");


        }
    }
}
