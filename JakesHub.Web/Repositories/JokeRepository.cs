using JakesHub.Web.Data;
using JakesHub.Web.Models;
using JakesHub.Web.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JakesHub.Web.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        private readonly JokesHubDbContext jokesHubDbContext;

        public JokeRepository(JokesHubDbContext jokesHubDbContext)
        {
            this.jokesHubDbContext = jokesHubDbContext;
        }
        public async Task<Joke> AddAsync(Joke joke)
        {
            await jokesHubDbContext.Jokes.AddAsync(joke);
            await jokesHubDbContext.SaveChangesAsync();
            return joke;
        }

        public async Task<Joke?> DeleteAsync(Guid id)
        {
            var existingJoke = await jokesHubDbContext.Jokes.FindAsync(id);
            if (existingJoke != null)
            {
                jokesHubDbContext.Jokes.Remove(existingJoke);
                await jokesHubDbContext.SaveChangesAsync();
                return existingJoke;
            }
            return null;
        }

        public async Task<IEnumerable<Joke>> GetAllAsync(string? SearchPhrase)
        {
            var query = jokesHubDbContext.Jokes.AsQueryable();
            if (string.IsNullOrWhiteSpace(SearchPhrase) == false)
            {
                query= query.Where(x=>x.JokeQuestion.Contains(SearchPhrase));
            }
            return await query.ToListAsync();

        }

        public async Task<Joke?> GetAsync(Guid id)
        {
            var joke = await jokesHubDbContext.Jokes.FirstOrDefaultAsync(x => x.Id == id);
            return joke;

        }

        public async Task<Joke?> UpdateAsync(Joke joke)
        {
            if (joke != null)
            {
                await jokesHubDbContext.Jokes.AddAsync(joke);
                await jokesHubDbContext.SaveChangesAsync();
                return joke;

            }
            else
            {
                return null;
            }

        }

        
    }
}
