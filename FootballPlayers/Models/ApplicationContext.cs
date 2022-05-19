using Microsoft.EntityFrameworkCore;

namespace FootballPlayers.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
