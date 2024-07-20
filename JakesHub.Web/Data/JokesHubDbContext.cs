using JakesHub.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace JakesHub.Web.Data
{
    public class JokesHubDbContext : DbContext
    {
        public JokesHubDbContext(DbContextOptions<JokesHubDbContext> options) : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; }
    }
}
