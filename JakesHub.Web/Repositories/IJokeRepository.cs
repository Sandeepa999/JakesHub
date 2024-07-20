using JakesHub.Web.Models;

namespace JakesHub.Web.Repositories
{
    public interface IJokeRepository
    {
        Task<IEnumerable<Joke>> GetAllAsync(string? SearchPhrase=null);
        Task<Joke?> GetAsync(Guid id);
        Task<Joke> AddAsync(Joke joke);
        Task<Joke?> UpdateAsync(Joke joke);
        Task<Joke?> DeleteAsync(Guid id);
        
    }
}
