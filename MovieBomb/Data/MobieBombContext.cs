using Microsoft.EntityFrameworkCore;

namespace MovieBomb.Models
{
    public class MovieBombContext : DbContext
    {
        public MovieBombContext (DbContextOptions<MovieBombContext> options)
            : base(options)
        {
        }

        public DbSet<MovieBomb.Models.Game> Game { get; set; }
        public DbSet<MovieBomb.Models.Round> Round { get; set; }
        public DbSet<MovieBomb.Models.Player> Player { get; set; }
    }
}
